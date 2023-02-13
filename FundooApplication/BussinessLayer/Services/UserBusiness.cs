using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Interfaces;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRespository user;
        public UserBusiness(IUserRespository user)
        {
            this.user = user;
        }

        public UserEntity Register (RegisterModel model)
        {
            return this.user.Register (model);
        }

        public string Login(LoginModel model)
        {
            return this.user.Login (model);
        }

        public string ForgetPassword(string Email)
        {
            return this.user.ForgetPassword (Email);
        }

        public string ResetPassword(ResetPassword reset, string Email)
        {
            return this.user.ResetPassword (reset, Email);
        }

        public UserTicket CreateTicketforPassword(string EmailID, string token)
        {
            return new UserTicket { EmailID = EmailID, Token = token};
        }

        public string DeleteUser(long UserID)
        {
            return this.user.DeleteUser (UserID);   
        }
    }
}
