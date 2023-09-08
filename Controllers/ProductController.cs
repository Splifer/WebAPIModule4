using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIModule4.Models;
using WebAPIModule4.Models.InputProduct;

namespace WebAPIModule4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Dbproject2Context _context;
        private readonly IConfiguration _config;

        public ProductController (IConfiguration config, Dbproject2Context context)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("lay-danh-sach-san-pham")]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("lay-san-pham-chi-dinh/{guid}")]
        public Product GetProduct(Guid guid)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == guid);
        }

        private string Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("No file selected.");

            var filename = Path.GetFileName(file.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot", "img",
                uniqueFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return _config["host"] + "/img/" + uniqueFileName;
        }

        [HttpPost("tao-san-pham")]
        public async Task<IActionResult> CreateProduct(InputProduct input)
        {
            //var imagePath = Upload(input.Icon);
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductId = Guid.NewGuid();
                product.ProductName = input.ProductName;
                product.Price = input.Price;
                //product.Icon = imagePath;
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPut("cap-nhat-san-pham/{guid}")]
        public async Task<IActionResult> UpdateProduct(Guid guid, InputProduct input)
        {
            //var imagePath = Upload(Product.Icon);
            var item = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == guid);
            if(ModelState.IsValid)
            {
                item.ProductName = input.ProductName;
                item.Price = input.Price;
                //item.Icon = input.Icon;
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete("xoa-san-pham")]
        public async Task<IActionResult> DeleteProduct(Guid guid)
        {
            var item = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == guid);
            _context.Products.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}