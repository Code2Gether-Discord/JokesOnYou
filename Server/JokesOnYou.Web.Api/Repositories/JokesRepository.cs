using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Filters;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline) =>
            _context.Jokes.AnyAsync(joke => joke.NormalizedPremise == normalizedPremise &&
                                            joke.NormalizedPunchLine == normalizedPunchline);

        public async Task CreateJokeAsync(Joke joke) => await _context.Jokes.AddAsync(joke).AsTask();
        public async Task<IEnumerable<Joke>> GetAllJokesAsync() => await _context.Jokes.ToListAsync();
        public async Task<IEnumerable<JokeDto>> GetAllJokeDtosAsync() => await _context.Jokes.ProjectTo<JokeDto>(_mapper.ConfigurationProvider).ToListAsync();
        public async Task<Joke> GetJokeByIdAsync(int id) => await _context.Jokes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<JokeDto> GetJokeDtoAsync(int id) => 
            await _context.Jokes
            .ProjectTo<JokeDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(j => j.Id == id);

        public void DeleteJoke(Joke joke) => _context.Jokes.Remove(joke);

        public async Task<IEnumerable<JokeDto>> GetFilteredJokeDtos(JokesFilter jokesFilter)
        {
           var filteredJokes = _context.Jokes.ProjectTo<JokeDto>(_mapper.ConfigurationProvider)
                .Where(joke => joke.Likes >= jokesFilter.MinLikes && joke.Likes <= jokesFilter.MaxLikes)
                .Where(joke => joke.Dislikes >= jokesFilter.MinDislikes && joke.Dislikes <= jokesFilter.MaxDislikes)
                .Where(joke => joke.UploadDate >= jokesFilter.MinUploadDate && joke.UploadDate <= jokesFilter.MaxUploadDate);
        
            if(jokesFilter.AuthorId != string.Empty)
            {
                filteredJokes = filteredJokes.Where(joke => joke.Author.Id == jokesFilter.AuthorId);
            }

            return await filteredJokes.ToListAsync();
        }
    }
}
