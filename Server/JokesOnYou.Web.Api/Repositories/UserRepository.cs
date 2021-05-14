using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<User> CreateUserAsync(UserRegisterDTO userRegisterDTO)
        {
            var userCreationResult = await _userManager.CreateAsync(new User()
            {
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.UserName
            }, userRegisterDTO.Password);
            if (userCreationResult.Succeeded)
            {
                return await _userManager.FindByEmailAsync(userRegisterDTO.Email);
            }
            else
            {
                StringBuilder message = new StringBuilder();
                foreach (var error in userCreationResult.Errors)
                {
                    message.AppendLine(error.Description);
                }

                throw new UserRegisterException(message.ToString(), new ArgumentException());
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username) => await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        public async Task<UserReplyDTO> GetUserReplyAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return _mapper.Map<User, UserReplyDTO>(user);
        }

        public Task DeleteUserAsync(User user) => _userManager.DeleteAsync(user);


        public async Task<User> GetUserAsync(string id) => await _userManager.FindByIdAsync(id);


        public async Task<User> GetUserByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);


        public async Task<IEnumerable<UserReplyDTO>> GetUsersAsync() => await _userManager.Users.ProjectTo<UserReplyDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }
}