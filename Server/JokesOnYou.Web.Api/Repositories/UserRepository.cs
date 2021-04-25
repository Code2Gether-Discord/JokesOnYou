using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using AutoMapper;
using JokesOnYou.Web.Api.Exceptions;

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

            var userCreationResult = await _userManager.CreateAsync(new User() { Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.UserName }, userRegisterDTO.Password);
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

        public Task DeleteUserAsync(User user) => _userManager.DeleteAsync(user);

        public async Task<UserReplyDTO> GetUserReplyAsync(string id)
        {
            //Possibilities 
            //var user = await _userManager.FindByIdAsync(id);
            //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            var user = await _userManager.FindByIdAsync(id);

            return _mapper.Map<UserReplyDTO>(user);
        }
        public async Task<User> GetUserAsync(string id)
        {
            //Possibilities 
            //var user = await _userManager.FindByIdAsync(id);
            //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return await _userManager.FindByIdAsync(id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }
        
    }
}