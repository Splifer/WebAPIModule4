using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIModule4.Models;

namespace WebAPIModule4.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly Dbproject2Context _context;

        public TokenController(IConfiguration config, Dbproject2Context context)
        {
            _configuration = config;
            _context = context;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(Account accountdata)
        //{
        //    if(accountdata != null && accountdata.LoginId != null && accountdata.Password != null)
        //    {
                
        //    }
        //}
    }
}