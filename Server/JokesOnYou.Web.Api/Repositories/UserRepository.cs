using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JokesOnYou.Web.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Remove(user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
