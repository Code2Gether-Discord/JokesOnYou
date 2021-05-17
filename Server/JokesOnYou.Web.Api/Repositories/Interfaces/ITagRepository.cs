using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync();
        Task CreateTagAsync(Tag tag); 
    }
}
