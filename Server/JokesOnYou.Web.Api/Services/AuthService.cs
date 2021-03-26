using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IUserRepository _userRepo;

        public AuthService(SignInManager<User> signInManager, IUserRepository userRepo)
        {
            _signInManager = signInManager;
            _userRepo = userRepo;
        }

        public User Login(UserLoginDTO userLoginDTO)
        {
            _signInManager.SignInAsync()
        }

        public User Register(UserRegisterDTO userRegisterDTO)
        {
            var user = _userRepo.CreateUserAsync(userRegisterDTO);
            return user.Result;
        }
    }
}
