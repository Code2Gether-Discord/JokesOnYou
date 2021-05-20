using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Profiles
{
    public class JokesProfile : Profile
    {
        public JokesProfile()
        {
            CreateMap<Joke, JokeReplyDto>();
            CreateMap<Joke, JokeWithAuthorReplyDto>()
                .ForMember(jwa => jwa.AuthorName, opt => opt.MapFrom(j => j.Author.Name));
            CreateMap<User, JokeAuthorDto>();
            CreateMap<JokeCreateDto, Joke>();
            CreateMap<JokeUpdateDto, Joke>();
        }
    }
}
