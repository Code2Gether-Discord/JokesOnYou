using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task DeleteTagAsync(Tag tag);
        Task<Tag> GetTagAsync(int id);
        Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync();
    }
}
