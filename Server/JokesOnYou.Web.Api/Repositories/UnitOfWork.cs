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
        /// <summary>
        /// Save changes to the Database.
        /// </summary>
        /// <returns>returns true if at least one change has been tracked</returns>
        public async Task<bool> SaveAsync()
        {
            //
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
