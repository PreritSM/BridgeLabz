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
    }
}
