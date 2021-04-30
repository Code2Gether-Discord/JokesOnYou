using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task Delete(int tagId);
        Task DeleteRange(int[] tagIds);
        Task<Tag> Find(int id);
        Task<List<Tag>> GetTags(int[] ids);
    }
}
