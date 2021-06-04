using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/Trips/All");
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = userService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserInputModel input)
        {
            if (String.IsNullOrEmpty(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Invalid Username");
            }

            if (!userService.IsUsernameAvailable(input.Username))
            {
                return this.Error("This username is already taken");
            }

            if (string.IsNullOrEmpty(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email");
            }

            if (!userService.IsEmailAvailable(input.Email))
            {
                return this.Error("This email is already taken.");
            }

            if (string.IsNullOrEmpty(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password is incorrect");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("Passowrds dont match");
            }
            this.userService.CreateUser(input.Username,input.Email, input.Password);

            return this.Redirect("/Users/Login");

        }


    }
}
