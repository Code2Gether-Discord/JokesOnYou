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
            if (_userManager.Users.Any(x => x.Email == userRegisterDTO.Email))
                throw new AppException($"Email {userRegisterDTO.Email} is already taken");

            if (_userManager.Users.Any(x => x.UserName == userRegisterDTO.UserName))
                throw new AppException($"Username: {userRegisterDTO.UserName} is already taken");

            var userCreationResult = await _userManager.CreateAsync(new User() { Email = userRegisterDTO.Email, UserName = userRegisterDTO.UserName }, userRegisterDTO.Password);
                
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

                throw new UserRegisterException(message.ToString());
            }   
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }

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
        public Task<User> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<UserReplyDTO>> GetUsersAsync()
        {
            //Such a waste of bits
            var users = await _userManager.Users.ToListAsync();
            
            return _mapper.Map<List<UserReplyDTO>>(users);
        }

        public async Task UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);
        }
        /*
         * Commented this out in case someone needs the code :)
        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) //no point in going forward if either of these is empty
                    throw new Exception("Password and Username are required");

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null) //no point going forward if user is empty
                return null;

            if (!await _userManager.CheckPasswordAsync(user, password)) //if password wrong, return
                return null;

            // authentication worked
            return user;

        }
        */
    }
}
