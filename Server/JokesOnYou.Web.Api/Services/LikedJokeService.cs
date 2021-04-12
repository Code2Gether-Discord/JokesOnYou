using JokesOnYou.Web.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class LikedJokeService
    {
        private readonly ILikedJokeRepository _likedJokeRepo;

        public LikedJokeService(ILikedJokeRepository likedJokeRepo)
        {
            _likedJokeRepo = likedJokeRepo;
        }
    }
}
