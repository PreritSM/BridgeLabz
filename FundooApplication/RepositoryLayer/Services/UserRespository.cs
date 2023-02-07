using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
            entity.Password= EncryptPassword(model.Password);
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

        public string EncryptPassword(string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Login(LoginModel loginModel)
        {
       //     string encodedPassword = EncryptPassword(loginModel.Password); 
            var IfExists = context.UserTable.Where(x => x.EmailID == loginModel.Email && x.Password == EncryptPassword(loginModel.Password)).FirstOrDefault();
            if (IfExists != null)
            {
                var token = GenerateJWTToken(IfExists.EmailID, IfExists.UserID);
                return token;
            }
            else
            {
                return null;
            }
        }

        public string GenerateJWTToken(string EmailID, long UserID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,EmailID),
                new Claim("UserID",UserID.ToString())
            };
            var token = new JwtSecurityToken(   
                issuer : configuration["Jwt:Issuer"],
                audience : configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
