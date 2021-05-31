using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Joke, JokeDto>().ForMember(dest => dest.Author, x => x.MapFrom(scr => new JokeAuthorDto() { Id = scr.AuthorId }));
                //.ForPath(dest => dest.Author.Id, x => x.MapFrom(scr => scr.AuthorId));
            CreateMap<JokeCreateDto, Joke>();
            CreateMap<JokeUpdateDto, Joke>();
        }
    }
}
