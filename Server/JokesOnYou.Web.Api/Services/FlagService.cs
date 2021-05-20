using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;

namespace JokesOnYou.Web.Api.Services
{
    public class FlagService : IFlagService
    {
        private readonly IFlagRepository _flagRepo;

        public FlagService(IFlagRepository flagRepo)
        {
            _flagRepo = flagRepo;
        }
    }
}
