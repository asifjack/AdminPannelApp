using AdminPannelApp.Models;
using AdminPannelApp.Repository.Interface;
using AdminPannelApp.Utils.Enums;
using AdminPannelApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Repository.Services
{
    public class AccountService : IUsers
    {
        private AppDbContext dBContex;
        public AccountService()
        {
            dBContex = new AppDbContext();
        }
        public SignInEnum SignIn(SignInModel model)
        {
            var user = dBContex.Users.SingleOrDefault(e=>e.Email==model.Email && e.Password==model.Password);
            if (user != null)
            {
                if (user.IsVerified)
                {
                    if (user.IsActive)
                    {
                        return SignInEnum.Success;
                    }
                    else
                    {
                        return SignInEnum.InActive;
                    }
                }
                else
                {
                    return SignInEnum.NotVerified;
                }
            }
            else
            {
                return SignInEnum.WrongCredentials;
            }
        }

        public SignUpEnum SignUp(SignUpModel model)
        {
            if (dBContex.Users.Any(e => e.Email == model.Email))
            {
                return SignUpEnum.EmailExist;
            }
            else 
            {
                var user = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.ConfirmPassword,
                    Gender = model.Gender
                };
                dBContex.Users.Add(user);
                dBContex.SaveChanges();
                return SignUpEnum.Success;

            }
           

        }
        private void SendEmailAuthentication()
        { 
        }
        private string GenerateOtp(string to , string username, string otp)
        {
            return "Otp";
        }
    }
}
