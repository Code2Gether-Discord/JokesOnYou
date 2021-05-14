using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAsync()
        {
            //returns true if atleast one change has been tracked
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
