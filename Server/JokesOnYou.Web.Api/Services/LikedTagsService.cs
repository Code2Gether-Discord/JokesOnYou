using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

namespace JokesOnYou.Web.Api.Services
{
    public class LikedTagsService : ILikedTagsService
    {
        private readonly ILikedTagsRepository _likedTagsRepo;

        public LikedTagsService(ILikedTagsRepository likedTagsRepo)
        {
            _likedTagsRepo = likedTagsRepo;
        }
    }
}
