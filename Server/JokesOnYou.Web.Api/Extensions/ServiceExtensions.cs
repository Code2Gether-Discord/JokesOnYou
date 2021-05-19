using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(connectionString)
            );

            services.AddIdentity<User, IdentityRole>(
                options => { options.User.RequireUniqueEmail = true; }
                ).AddEntityFrameworkStores<DataContext>();

            var key = Encoding.ASCII.GetBytes("We need to use a Secret Handler here");

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }


    }
}
