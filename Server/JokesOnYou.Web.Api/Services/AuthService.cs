using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class AuthService
    {
        private readonly SignInManager<User> _signInManager;

        public AuthService(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        User Login(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        User Register(UserRegisterDTO userRegisterDTO)
        {
            _signInManager.
        }
    }
}
