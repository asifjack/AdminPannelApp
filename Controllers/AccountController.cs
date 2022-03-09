using AdminPannelApp.Repository.Interface;
using AdminPannelApp.Utils.Enums;
using AdminPannelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Controllers
{
    public class AccountController : Controller
    {
        private IUsers UserService;
        public AccountController(IUsers users)
        {
            UserService = users;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(SignInModel model)
        {
            var result = UserService.SignIn(model);
            if (result == SignInEnum.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (result==SignInEnum.WrongCredentials)
            {
                ModelState.AddModelError(string.Empty, "InValid Login Credential");
            }
            else if (result == SignInEnum.NotVerified)
            {
                ModelState.AddModelError(string.Empty, "User Not Verified");
            }
            else if (result == SignInEnum.InActive)
            {
                ModelState.AddModelError(string.Empty, "Your Account is InActive");
            }

            return View(model);
        }
    }
}







