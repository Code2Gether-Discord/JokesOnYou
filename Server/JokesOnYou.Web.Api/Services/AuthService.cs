using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
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
        private readonly ITokenService _tokenService;

        public AuthService(SignInManager<User> signInManager, IUserRepository userRepo, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<UserReplyDTO> LoginAsync(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
