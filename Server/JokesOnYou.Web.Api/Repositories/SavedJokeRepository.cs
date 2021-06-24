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
using JokesOnYou.Web.Api.DTOs;
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

        public async Task AddSavedJoke(SavedJoke savedJoke) => await _context.SavedJokes.AddAsync(savedJoke);
        public async Task<IEnumerable<SavedJokeReplyDto>> GetSavedJokesByUserId(string id) => await _context.SavedJokes.Where(x=> x.UserId == id).ProjectTo<SavedJokeReplyDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
