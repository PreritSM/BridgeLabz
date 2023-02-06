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
    }
}
