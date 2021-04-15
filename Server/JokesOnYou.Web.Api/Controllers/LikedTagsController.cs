using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    public class LikedTagsController : ControllerBase
    {
        private readonly ILikedTagsService _likedTagsService;

        public LikedTagsController(ILikedTagsService likedTagsService)
        {
            _likedTagsService = likedTagsService;
        }
    }
}
