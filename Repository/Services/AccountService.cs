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

        public SignUpEnum SignUp(SignInModel model)
        {
            throw new NotImplementedException();
        }
    }
}
