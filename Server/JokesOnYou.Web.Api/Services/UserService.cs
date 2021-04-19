using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JokesOnYou.Web.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(UserUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReplyDTO> LoginUser(UserLoginDTO userLogin)
        {
            var user = await _userRepository.GetUserByEmail(userLogin.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (signInResult.Succeeded)
                {
                    var userReplyDTO = new UserReplyDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.Email,
                        Role = "",
                        Token = _tokenService.GetToken(user)
                    };
                    return userReplyDTO;
                }
                else
                {
                    throw new NotImplementedException("Sign in failed");
                }
            }
            else
            {
                throw new NotImplementedException("User not found"); 
            }
        }

        public async Task<User> RegisterUser (UserRegisterDTO userRegisterDTO)
        {
            return await _userRepository.CreateUserAsync(userRegisterDTO); 
        }
    }
}
