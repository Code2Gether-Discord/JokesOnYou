using AutoMapper;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserLoginDTO, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserReplyDto>();
            CreateMap<User, JokeAuthorDto>();
            CreateMap<SavedJoke, SavedJokeReplyDto>();
        }
    }
}
