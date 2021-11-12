using AutoMapper;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagReplyDto>();
            CreateMap<Tag, LikedTagReplyDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
