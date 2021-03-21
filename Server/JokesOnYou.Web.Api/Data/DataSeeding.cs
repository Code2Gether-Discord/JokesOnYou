using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Migrations;
using JokesOnYou.Web.Api.Models;
using System.Text.Json;

namespace JokesOnYou.Web.Api.Data
{
    public class DataSeeding
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated(); //Make sure db actually exists

            // Look for any users in db
            if (context.Users.Any())
            {
                //If there are students then leave method
                return;
            }

            //If you go here than it means that the db is empty
            var TemporaryUsers = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(@"Data\UserSeedData.json"));
            
            //adds users to db
            context.Users.AddRange(TemporaryUsers);

            //always remember to save
            context.SaveChanges();

        }
    }
}
