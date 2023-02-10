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

        public string ForgetPassword(string Email)
        {
            var EmailCheck =this.context.UserTable.Where(x => x.EmailID == Email).FirstOrDefault();
            if (EmailCheck != null)
            {
                var token = GenerateJWTToken(EmailCheck.EmailID, EmailCheck.UserID);
                new MSMQ().SendMessage(token, EmailCheck.EmailID,EmailCheck.FirstName);
                return token;
            }
            else
            {
                return null;
            }
        }

        public string ResetPassword(ResetPassword reset,string Email) 
        {
            try
            {
                if(reset.NewPassword.Equals(reset.ConfirmPassword))
                {
                    var EmailCheck = context.UserTable.Where(b=> b.EmailID== Email).FirstOrDefault();
                    EmailCheck.Password = EncryptPassword(reset.ConfirmPassword);
                    context.SaveChanges();
                    return "Reset Done";
                }
                else 
                {
                    return null;

                }
            }
            catch(Exception ex)
            {
                return ex.Message;
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

        public UserTicket CreateTicketforPassword(string EmailID, string token)
        {
            var userDetail = context.UserTable.FirstOrDefault(context => context.EmailID == EmailID);
            if (userDetail != null)
            {
                UserTicket userTicket = new UserTicket
                {
                    FirstName = userDetail.FirstName,
                    LastName = userDetail.LastName,
                    EmailID = EmailID,
                    Token= token,
                    CreatedAt= DateTime.Now

                };
                return userTicket;
            }
            else
            {
                return null;
            }
        }
    }
}
