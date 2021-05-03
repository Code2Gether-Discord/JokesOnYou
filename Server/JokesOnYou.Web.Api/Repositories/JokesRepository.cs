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

        public async Task<IEnumerable<Joke>> GetAllJokesAsync()
        {
            var jokes = await _context.Jokes.Include( joke => joke.Author).ToListAsync();
            return jokes;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _context.Jokes.ProjectTo<JokeReplyDto>(_mapper.ConfigurationProvider).ToListAsync();

            return jokeDtos;
        }
    }
}
