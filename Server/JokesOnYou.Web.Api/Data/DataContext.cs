using System;
using Microsoft.EntityFrameworkCore;

namespace JokesOnYou.Web.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
