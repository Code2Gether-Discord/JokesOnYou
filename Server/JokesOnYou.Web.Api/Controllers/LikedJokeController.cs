using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokesOnYou.Web.Api.Controllers
{
    public class LikedJokeController : ControllerBase
    {
        private readonly ILikedJokeService _likedJokeService;

        public LikedJokeController(ILikedJokeService likedJokeService)
        {
            _likedJokeService = likedJokeService;
        }
    }
}
