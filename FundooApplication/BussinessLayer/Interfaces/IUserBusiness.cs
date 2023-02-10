using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Entity;

namespace BussinessLayer.Interfaces
{
    public interface IUserBusiness
    {
        public UserEntity Register(RegisterModel model);

        public string Login(LoginModel model);
        public string ForgetPassword(string Email);

        public string ResetPassword(ResetPassword reset, string Email);

        public UserTicket CreateTicketforPassword(string EmailID, string token);
    }
}
