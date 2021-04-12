using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
