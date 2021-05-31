using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagReplyDto>();
            CreateMap<TagCreateDto, Tag>();
        }
    }
}
