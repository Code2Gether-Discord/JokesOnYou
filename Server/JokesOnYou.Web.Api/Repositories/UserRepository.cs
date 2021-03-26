using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
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
            var user = await _userManager.CreateAsync(new User() { Email = userRegisterDTO.Email }, userRegisterDTO.Password);

            if (user.Succeeded)
            {
                user.
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<User> GetUserAsync(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }
    }
}
