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

namespace JokesOnYou.Web.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> CreateUserAsync(UserRegisterDTO userRegisterDTO)
        {
            // validation thingy
            if (string.IsNullOrWhiteSpace(userRegisterDTO.Password))
                throw new Exception("Password is required");

            if (_userManager.Users.Any(x => x.Email == userRegisterDTO.Email))
                throw new Exception($"Email {userRegisterDTO.Email} is already taken");

            if (_userManager.Users.Any(x => x.UserName == userRegisterDTO.UserName))
                throw new Exception($"Username: {userRegisterDTO.UserName} is already taken");

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

        public Task<User> GetUserAsync(string id)
        {
            //Possibilities 
            //var user = await _userManager.FindByIdAsync(id);
            //var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _userManager.FindByIdAsync(id);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            //Does not need to be awaited here.
            return await _userManager.Users.ToListAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                await _userManager.UpdateAsync(user);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            // The true and false thing is to just make sure that everything is working 😎
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) //no point in going forward if either of these is empty
                return null;

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null) //no point going forward if user is empty
                return null;

            if (!await _userManager.CheckPasswordAsync(user, password)) //if password wrong, return
                return null;

            // authentication worked
            return user;

        }

    }
}
