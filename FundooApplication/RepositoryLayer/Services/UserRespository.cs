using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class UserRespository : IUserRespository
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;
        public UserRespository( FundooDBContext context,IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public UserEntity Register(RegisterModel model)
        {
            UserEntity entity = new UserEntity();
            entity.FirstName= model.FirstName;
            entity.LastName= model.LastName;
            entity.EmailID= model.EmailID;
            entity.Password= model.Password;
            context.UserTable.Add(entity);
            int res = context.SaveChanges();
            if (res > 0)
            {
                return entity;
            }
            else 
            { 
                return null; 
            }

        }
    }
}
