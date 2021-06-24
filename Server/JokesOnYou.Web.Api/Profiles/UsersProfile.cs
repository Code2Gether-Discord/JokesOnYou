using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserReplyDTO>();
            CreateMap<SavedJoke, SavedJokeReplyDto>();
        }
    }
}
