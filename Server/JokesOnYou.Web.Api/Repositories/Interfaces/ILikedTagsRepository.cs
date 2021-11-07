using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ILikedTagsRepository
    {

        void DeleteLikedTag(LikedTags likedTags);

        Task AddLikedTag(LikedTags likedTags);

        Task<IEnumerable<LikedTags>> GetLikedTagByUserId(string userId);

        Task<LikedTags> GetLikedTag(string userId, int tagId);
    }
}
