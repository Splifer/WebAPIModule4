namespace WebAPIModule4.Models.InputProduct
{
    public class InputProduct
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public IFormFile? Icon { get; set; }
    }
}