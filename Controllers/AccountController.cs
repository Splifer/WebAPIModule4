using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebAPIModule4.Models;
using WebAPIModule4.Models.InputAccount;

namespace WebAPIModule4.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Dbproject2Context _context;

        public AccountController(Dbproject2Context context)
        {
            _context = context;
        }

        [HttpGet("lay-danh-sach-tai-khoan")]
        public List<Account> GetAccount()
        {
            return _context.Accounts.ToList();
        }

        [HttpGet("lay-tai-khoan-chi-dinh/{guid}")]
        public Account GetAccount(Guid guid)
        {
            return _context.Accounts.FirstOrDefault(x => x.UserId == guid);
        }

        [HttpPost("tao-tai-khoan")]
        public async Task<IActionResult> CreateAccount(InputAccount input)
        {
            if(ModelState.IsValid)
            {
                Account account = new Account();
                account.UserId = Guid.NewGuid();
                account.LoginId = input.LoginId;
                account.Password = input.Password;
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                return Ok(account);
            }
            return NotFound();
        }

        [HttpPut("cap-nhat-tai-khoan/{guid}")]
        public async Task<IActionResult> UpdateAccount(Guid guid, InputAccount input)
        {
            var item = await _context.Accounts.FirstOrDefaultAsync(x => x.UserId == guid);
            if(ModelState.IsValid)
            {
                item.LoginId = input.LoginId;
                item.Password = input.Password;
                _context.Update(item);
                await _context.SaveChangesAsync();
                return Ok(item);
            }
            return NotFound();
        }

        [HttpDelete("xoa-tai-khoan")]
        public async Task<IActionResult> DeleteAccount(Guid guid)
        {
            var item = await _context.Accounts.FirstOrDefaultAsync(x => x.UserId == guid);
            _context.Accounts.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}