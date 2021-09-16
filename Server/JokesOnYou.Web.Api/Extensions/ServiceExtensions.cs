using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration config)
        {
            var useSQLite = true;
            var connectionString = useSQLite ? config.GetConnectionString("SQLite") : config.GetConnectionString("PostgresConnectionString");

            services.AddDbContext<DataContext>(options =>
            {
                if (useSQLite) options.UseSqlite(connectionString);
                else options.UseNpgsql(connectionString, o => o.EnableRetryOnFailure(5));
            });

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

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                //appcontext base directory is where the app entry point assembly is (bin folder)
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "JokesOnYou.Web.Api.xml"));

                //add authorization option to Swagger UI
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header **_WITHOUT_** 'Bearer'. Example: '12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                //make sure swagger uses authorization token in requests
                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }
    }
}
