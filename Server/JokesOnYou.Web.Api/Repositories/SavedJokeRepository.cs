using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace JokesOnYou.Web.Api.Repositories
{
    public class SavedJokeRepository : ISavedJokeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SavedJokeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            
        public void DeleteSavedJoke(SavedJoke savedjoke) => _context.SavedJokes.Remove(savedjoke);

        public async Task AddSavedJoke(SavedJoke savedJoke) => await _context.SavedJokes.AddAsync(savedJoke);

        public IEnumerable<SavedJoke> GetSavedJokesByUserId(string id) =>
            _context.SavedJokes.Where(x => x.UserId == id).ToList();

        public async Task<SavedJoke> GetSavedJoke(string id, int jokeId) =>
            await _context.SavedJokes.FirstOrDefaultAsync(x => x.UserId == id && x.JokeId == jokeId);
    }
}