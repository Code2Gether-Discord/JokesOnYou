using JokesOnYou.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ILikeForTagsRepository
    {

        void DeleteLikedTag(LikeForTag likedTag);

        Task AddLikedTag(LikeForTag likedTag);

        Task<IEnumerable<LikeForTag>> GetLikedTagByUserId(string userId);

        Task<LikeForTag> GetLikedTag(string userId, int tagId);
    }
}
