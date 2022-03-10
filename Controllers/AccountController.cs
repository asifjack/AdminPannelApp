using AdminPannelApp.Repository.Interface;
using AdminPannelApp.Utils.Enums;
using AdminPannelApp.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Login(SignInModel model)
        {
            var result = UserService.SignIn(model);
            if (result == SignInEnum.Success)
            {
                //A claim is a statement about a subject by an issuer and    
                //represent attributes of the subject that are useful in the context of authentication and authorization operations.    
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, model.Email),
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new
                    AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                });
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
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(SignUpModel model)
        {
            var result = UserService.SignUp(model);
            return View();
        }

    }
}







