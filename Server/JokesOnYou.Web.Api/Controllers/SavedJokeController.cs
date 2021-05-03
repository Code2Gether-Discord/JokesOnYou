using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    public class SavedJokeController : ControllerBase
    {
        private readonly ISavedJokeService _savedJokeService;

        public SavedJokeController(ISavedJokeService savedJokeService)
        {
            _savedJokeService = savedJokeService;
        }
    }
}
