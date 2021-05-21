using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Joke, JokeReplyDto>();
            CreateMap<Joke, JokeWithAuthorReplyDto>();
            CreateMap<User, JokeAuthorDto>();
            CreateMap<JokeCreateDto, Joke>();
            CreateMap<JokeUpdateDto, Joke>();
        }
    }
}
