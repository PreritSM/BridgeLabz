using System;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserBusiness user)
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
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "Register Successfull", Data = registerData, });
            }
            else
            {
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
    }
}
