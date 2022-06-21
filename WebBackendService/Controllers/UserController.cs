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
        public IEnumerable<User> Get()
        {
            List<User> users = new List<User>();
            foreach (User u in UserManager.UsersList)
            {
                User _user = u.clone();
                _user.Password = "";
                users.Add(_user);
            }
            return users;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            _logger.LogTrace("User {userName} try Login", user.UserName);
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

        [HttpPost("UpdateUserList")]
        public async Task<IActionResult> UpdateUserList([FromBody] List<User> userList)
        {
            try
            {
                foreach (User? user in userList)
                {
                    var _u = UserManager.UsersList.FirstOrDefault(u => u.UserName == user.UserName);
                    if (_u != null)
                    {
                        _u.AccountName = user.AccountName;
                        _u.Level = user.Level;
                    }
                    else
                    {
                        UserManager.TryCreate(user.AccountName, user.UserName, "", out string message, 0);
                    }
                }
                UserManager.SaveUsersList();
                return Ok(new ResultBase
                {
                    Success = true,
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResultBase
                {
                    Success = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
        {
            try
            {
                bool success = UserManager.ChangePassword(changePasswordModel, out string message);
                return Ok(new ResultBase()
                {
                    Success = success,
                    Message = message,
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResultBase()
                {
                    Success = false,
                    Message = ex.Message,
                });
            }

        }
    }
}

