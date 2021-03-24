using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Repositories.Interfaces;

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
