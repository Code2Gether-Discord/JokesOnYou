using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Migrations;
using JokesOnYou.Web.Api.Models;
using Newtonsoft.Json;

namespace JokesOnYou.Web.Api.Data
{
    public class DataSeeding
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated(); //Make sure db actually exists

            // Look for any students.
            if (context.Users.Any())
            {
                return;
            }

            var jsonThingy = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(AppContext.BaseDirectory + "SeedingDB.json"));

            foreach (var item in jsonThingy)
            {
                context.Users.Add(item);
            }
            context.SaveChanges();

        }
    }
}
