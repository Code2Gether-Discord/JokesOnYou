using AutoMapper;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.DTOs;

namespace JokesOnYou.Web.Api.Profiles
{
    public class SavedJokeProfiles : Profile
    {
        public SavedJokeProfiles()
        {
            CreateMap<SavedJoke, SavedJokeReplyDto>();
        }
    }
}