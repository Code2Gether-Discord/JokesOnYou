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
        private readonly ITokenService _ITokenService;

        public UserService(IUserRepository userRepository, SignInManager<User> signInManager, ITokenService ITokenService)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
            _ITokenService = ITokenService;
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
            UserReplyDTO myUserReplyDTO = null; 
            var user = await _userRepository.GetUserByEmail(userLogin.Email);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (signInResult.Succeeded)
                {
                    myUserReplyDTO = new UserReplyDTO()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        UserName = user.Email,
                        Role = "",
                        Token = _ITokenService.GetToken(user)
                    };
                }
            }
            return myUserReplyDTO;
        }
    }
}
