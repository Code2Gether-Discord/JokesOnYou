using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
