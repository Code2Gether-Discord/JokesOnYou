using JokesOnYou.Web.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<bool> Delete(TagCreateDto tag);
        Task<bool> Delete(int tagId);
        Task<bool> DeleteRange(List<TagCreateDto> tags);
        Task<bool> DeleteRange(int[] tagIds);
    }
}
