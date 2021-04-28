using System;
using JokesOnYou.Web.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;



namespace JokesOnYou.Web.Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    
        public DbSet<Joke> Jokes { get; set; }
        public DbSet<Tag> Tag { get; set; }
        //For each class in models folder, add it here, only if its also in db
    }
}
