using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

namespace JokesOnYou.Web.Api.Services
{
    public class LikedJokeService : ILikedJokeService
    {
        private readonly ILikedJokeRepository _likedJokeRepo;

        public LikedJokeService(ILikedJokeRepository likedJokeRepo)
        {
            _likedJokeRepo = likedJokeRepo;
        }
    }
}
