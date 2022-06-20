using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackendService.Models.USER;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBackendService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private ILogger _logger;
        public UserController(ILogger<UserController> Logger)
        {
            _logger = Logger;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return UserManager.UsersList.Select(usr => usr.UserName);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            _logger.LogTrace("User {userName} try Login",user.UserName);
            bool success = UserManager.TryValidation(user, out int level, out string message);
            LoginResult loginResult = new LoginResult
            {
                Success = success,
                UserName = !success ? "" : user.UserName,
                Level = level,
                Message = message
            };
            return Ok(loginResult);
        }

        [HttpPost("Regist")]
        public async Task<IActionResult> Regist([FromBody] User user)
        {
            bool success = UserManager.TryCreate(user.AccountName, user.UserName, user.Password, out string message);

            RegistResult registResult = new RegistResult
            {
                Success = success,
                Message = message,
                UserName = user.UserName
            };

            return Ok(registResult);
        }

    }
}

