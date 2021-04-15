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
            CreateMap<Joke, JokeReplyDto>()
                .ForPath(destination => destination.Author.Id, options =>
                    options.MapFrom(Source => Source.Author.Id))
                .ForPath(destination => destination.Author.UserName, options =>
                    options.MapFrom(source => source.Author.UserName));
        }
    }
}
