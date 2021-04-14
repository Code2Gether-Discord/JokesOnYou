using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class JokesRepository : IJokesRepository
    {
        private readonly DataContext _context;

        public JokesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Joke>> GetAllJokesAsync()
        {
            var jokes = await _context.Jokes.ToListAsync();
            return jokes;
        }
    }
}
