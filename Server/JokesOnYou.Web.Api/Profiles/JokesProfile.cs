using AutoMapper;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Joke, JokeReplyDto>().ForMember(dest => dest.Author, x => x.MapFrom(src => new JokeAuthorDto() { Id = src.AuthorId }));
            CreateMap<JokeCreateDto, Joke>().ForMember(dest => dest.AuthorId, x => x.MapFrom(source => source.UserId));
            CreateMap<JokeUpdateDto, JokeCreateDto>();
            CreateMap<JokeDto, JokeCreateDto>();
            CreateMap<JokeUpdateDto, Joke>();
        }
    }
}
