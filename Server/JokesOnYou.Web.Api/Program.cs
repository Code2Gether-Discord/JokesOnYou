using JokesOnYou.Web.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace JokesOnYou.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();

        }
        private static void CreateDbIfNotExists(IHost host)
        {

            var path1 = AppDomain.CurrentDomain.BaseDirectory;
            var path2 = AppContext.BaseDirectory;

            var dirInfo = new DirectoryInfo(path1);
            var dirInfo2 = new DirectoryInfo(path2);
            var dir1 = dirInfo.GetDirectories();
            var dir2 = dirInfo2.GetDirectories();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {

                    var context = services.GetRequiredService<DataContext>();
                    context.Database.EnsureCreated();
                    DataSeeding.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating / trying to access the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
