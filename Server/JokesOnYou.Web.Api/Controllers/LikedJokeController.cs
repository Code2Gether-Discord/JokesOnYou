using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
