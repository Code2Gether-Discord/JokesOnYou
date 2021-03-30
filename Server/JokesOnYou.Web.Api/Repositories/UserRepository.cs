using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var userCreationResult = await _userManager.CreateAsync(new User() { Email = userRegisterDTO.Email, UserName = userRegisterDTO.Email }, userRegisterDTO.Password);

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

        public Task DeleteUserAsync(User user) => _userManager.DeleteAsync(user);

        public Task<User> GetUserAsync(string id) => _userManager.FindByIdAsync(id);

        public Task<User> GetUserByEmail(string email) => _userManager.FindByEmailAsync(email);

        public async Task<IEnumerable<User>> GetUsersAsync() => await _userManager.Users.ToListAsync();
    }
}
