using JokesOnYou.Web.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JokesOnYou.Web.Api.Data
{
    public class DataSeeding
    {
        public static void Initialize(DataContext context)
        {

            // Oooh boy, we want to make sure we've migrated everything.
            // We should revisit this when we look at deploying to production, we can run into issues around
            // multiple instances calling a database and causing issues. See
            // https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#apply-migrations-at-runtime
            ApplyMigrations(context);

            // Look for any users in db
            if (context.Users.Any())
            {
                //If there are users then leave method
                return;
            }

            //If you go here than it means that the db is empty
            var temporaryUsers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "UserSeedData.json")),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            //adds users to db
            context.Users.AddRange(temporaryUsers);

            //always remember to save
            context.SaveChanges();

        }

        public static void ApplyMigrations(DataContext context)
        {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
