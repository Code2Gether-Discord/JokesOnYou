using JokesOnYou.Web.Api.Models;
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
            context.Database.EnsureCreated(); //Make sure db actually exists

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
    }
}
