using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlite(config.GetConnectionString("Default")));

            return services;
        }

    }
}
