using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Response;
using System.Linq;
using System;
using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Extensions;

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

        public async Task<bool> DoesJokeExist(string normalizedPremise, string normalizedPunchline) =>
            await _context.Jokes.AnyAsync(joke => joke.NormalizedPremise == normalizedPremise &&
                                                joke.NormalizedPunchLine == normalizedPunchline);

        public async Task CreateJokeAsync(Joke joke) => await _context.Jokes.AddAsync(joke).AsTask();

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync() =>
            await _context.Jokes.ProjectTo<JokeReplyDto>(_mapper.ConfigurationProvider).ToListAsync();

        public async Task<Joke> GetJokeByIdAsync(int id) =>
            await _context.Jokes.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<JokeReplyDto> GetJokeDtoAsync(int id) =>
            await _context.Jokes.ProjectTo<JokeReplyDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(j => j.Id == id);

        public void DeleteJoke(Joke joke) => _context.Jokes.Remove(joke);

        public async Task<PaginatedList<JokeReplyDto>> GetJokeDtosAsync(JokesFilterDto jokesFilter)
        {
            var query = _context.Jokes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(jokesFilter.AuthorId))
            {
                query = query.Where(joke => joke.AuthorId == jokesFilter.AuthorId);
            }
            if (jokesFilter.MinimumLikes != int.MinValue || jokesFilter.MaximumLikes != int.MaxValue)
            {
                query = query.Where(joke => joke.Likes >= jokesFilter.MinimumLikes && joke.Likes <= jokesFilter.MaximumLikes);
            }
            if (jokesFilter.MinimumDate != DateTime.MinValue || jokesFilter.MaximumDate != DateTime.MaxValue)
            {
                query = query.Where(joke => joke.UploadDate >= jokesFilter.MinimumDate && joke.UploadDate <= jokesFilter.MaximumDate.AddDays(1));
            }
            if (string.IsNullOrEmpty(jokesFilter.SearchText) == false || string.IsNullOrWhiteSpace(jokesFilter.SearchText) == false)
            {
                query = query.Where(x => x.NormalizedPremise.Contains(jokesFilter.SearchText.ToUpper()) ||
                x.NormalizedPunchLine.Contains(jokesFilter.SearchText.ToUpper()));
            }

            int count;
            (query, count) = await query.PaginateAsync(jokesFilter.PageNumber, jokesFilter.PageSize);

            var relatedAuthors = await _context.Users
                .Where(u => query.Select(j => j.AuthorId).Contains(u.Id))
                .Select(u => new { u.UserName, u.Id })
                .ToListAsync();

            var jokes = await query.ProjectTo<JokeReplyDto>(_mapper.ConfigurationProvider).ToListAsync();

            jokes = jokes.Select(j =>
                {
                    j.Author.UserName = relatedAuthors.FirstOrDefault(x => x.Id == j.Author.Id).UserName;
                    return j;
                }).ToList();

            return new PaginatedList<JokeReplyDto>(jokes, count, jokesFilter.PageNumber, jokesFilter.PageSize);
        }
    }
}
