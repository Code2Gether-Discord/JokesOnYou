using JokesOnYou.Web.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokesOnYou.Web.Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Joke> Jokes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
