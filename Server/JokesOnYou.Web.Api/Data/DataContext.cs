using System;
using JokesOnYou.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;



namespace JokesOnYou.Web.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Joke> Jokes { get; set; }
        //For each class in models folder, add it here, only if its also in db
        // This is what was written in the wiki by ChrisK
    }
}
