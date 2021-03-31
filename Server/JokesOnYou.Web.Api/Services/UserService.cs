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
using JokesOnYou.Web.Api.Exceptions;

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
            var user = await _userRepository.GetUserAsync(id) ?? null;

            if (user == null)
                throw new Exception();

            var userToDelete = new User { Id = user.Id };

            await _userRepository.DeleteUserAsync(userToDelete);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return await _userRepository.GetUsersAsync();
        }
       
        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task UpdateUser(UserUpdateDTO updateDTO)
        {
            // something something darkside
        }

        public async Task<UserReplyDTO> LoginUser(UserLoginDTO userLogin)
        {
            var user = await _userRepository.GetUserByEmail(userLogin.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (!signInResult.Succeeded)
                {
                    throw new AppException("Sign in failed");
                }
                else
                {
                    var userReplyDTO = new UserReplyDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.Email,
                        Token = _tokenService.GetToken(user)
                    };
                    return userReplyDTO;
                }
            }
            else
            {
                throw new AppException("User not found");
            }
        }

        public async Task RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            var user = await _userRepository.CreateUserAsync(userRegisterDTO);

            if (user == null)
            {
                throw new AppException("Failed to find user in the Database.");
            }
        }
    }
}
