using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JokesOnYou.Web.Api.Controllers
{
    public class ReasonController : ControllerBase
    {
        private readonly IReasonService _reasonService;

        public ReasonController(IReasonService reasonService)
        {
            _reasonService = reasonService;
        }
    }
}
