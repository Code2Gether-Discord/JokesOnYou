using System.Collections.Generic;
using System.Threading.Tasks;
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
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            _userManager.CheckPasswordAsync(user, password);

        }

    }
}
