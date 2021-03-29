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
            var user = await _userRepo.GetUserByEmail(userLoginDTO.Email);
            //TODO add user validation Not null

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

            //var result = await _signInManager.PasswordSignInAsync(userLoginDTO.Email, userLoginDTO.Password, false, false);

            if (result.Succeeded)
            {
                //TODO need to assign user a role!
                UserReplyDTO userReplyDTO = new UserReplyDTO() { Email = user.Email, Id = user.Id, UserName = user.UserName, Role = "Registered" };

                string token = _tokenService.GetToken(user);
                userReplyDTO.Token = token;

                return userReplyDTO;
            }
            else
            {
                throw new UserLoginException("Bad UserName or Password!");
                //return null;
            }

        }

        public async Task<User> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            var user = await _userRepo.CreateUserAsync(userRegisterDTO);
            //TODO catch Errors for creating user Account.
            return user;
        }
    }
}
