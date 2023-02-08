using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRespository
    {
        public UserEntity Register(RegisterModel model);
        public string Login(LoginModel loginModel);
        public string ForgetPassword(string Email);
        public string ResetPassword(ResetPassword reset, string Email);
    }
}
