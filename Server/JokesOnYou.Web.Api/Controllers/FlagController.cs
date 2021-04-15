using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Controllers
{
    public class FlagController : ControllerBase
    {
        private readonly IFlagService _flagService;

        public FlagController(IFlagService flagService)
        {
            _flagService = flagService;
        }
    }
}
