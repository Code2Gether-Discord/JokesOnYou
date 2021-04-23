using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.DTOs;
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
        private readonly IMapper _mapper;

        public JokesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //TODO change tolower use normalized premise And add normalizedPunchline check after that.
        public async Task<IEnumerable<Joke>> GetJokesByPremiseAsync(string premise)
        {
            var lowerPremise = premise.ToLower();
            var jokes = await _context.Jokes.Where(joke => joke.Premise.ToLower() == lowerPremise).ToListAsync();

            return jokes;
        }

        public Task CreateJokeAsync(Joke joke) => _context.Jokes.AddAsync(joke).AsTask();
        public Task<List<Joke>> GetAllJokesAsync() => _context.Jokes.ToListAsync();
        public Task<List<JokeReplyDto>> GetAllJokeDtosAsync() => _context.Jokes.ProjectTo<JokeReplyDto>(_mapper.ConfigurationProvider).ToListAsync();
    }
}
