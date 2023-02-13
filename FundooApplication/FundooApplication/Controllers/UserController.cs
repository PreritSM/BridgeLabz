using System;
using System.Linq;
using System.Security.Claims;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness user;
        private readonly ILogger<UserController> logger ;    
        public UserController(IUserBusiness user,ILogger<UserController> logger)
        {
            this.user = user;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterModel model)
        {
            var registerData = user.Register(model);
            if (registerData != null)
            {
                logger.LogInformation("Register Successful");
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register Successfull", Data = registerData, });
            }
            else
            {
                logger.LogInformation("Register Successful");
                return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "Register Failed" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                var LoginData = user.Login(model);
                if (LoginData != null)
                {
                    return Ok(new ResponseModel<string> { Status = true, Message = "Login Succesful", Data = LoginData });
                }
                else
                {
                    return BadRequest(new ResponseModel<string> { Status = false, Message = "login Failed" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("ForgetPassword")]

        public IActionResult ForgetPassword (string Email) {
        
            var forget = user.ForgetPassword(Email);
            if (forget!= null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Mail Sent Succesfully", Data = forget });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Mail Not Sent" });
            }
        }
        [Authorize]
        [HttpPatch("ResetPassword")]

        public IActionResult ResetPassword(ResetPassword reset)
        {
            // var Email = User.Claims.FirstOrDefault(b => b.Type == "EmailID").Value;
            var Email = User.FindFirst(ClaimTypes.Email).Value;
            var forget = user.ResetPassword(reset,Email);
            if (forget != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Password Reset", Data = "Reset Done"  });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Reset Unsuccessful" });
            }
        }

        [HttpPost("Delete-User")]
        public IActionResult DeleteUser(long id)
        {
            var msg = user.DeleteUser(id);
            if (msg != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "User Deleted", Data = msg });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "User does't Exist or Process failed" });
            }
        }
    }
}
