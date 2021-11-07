using System;
using System.IO;
using System.Text;
using JokesOnYou.Web.Api.Data;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Options;
using JokesOnYou.Web.Api.Repositories;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace JokesOnYou.Web.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IJokesService, JokesService>();
            services.AddScoped<ISavedJokeService, SavedJokeService>();
            services.AddScoped<ILikedTagsService, LikedTagsService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJokesRepository, JokesRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ISavedJokeRepository, SavedJokeRepository>();
            services.AddScoped<ILikedTagsRepository, LikedTagsRepository>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("SQLserverConnection"));
            });

            services.AddIdentity<User, IdentityRole>(
                options => { options.User.RequireUniqueEmail = true; }
                ).AddEntityFrameworkStores<DataContext>();
        }

        public static void ConfigureJwtAuth(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtTokenKey>(config);
            var jwtTokenKey = config.Get<JwtTokenKey>();

            var key = Encoding.ASCII.GetBytes(jwtTokenKey.TokenKey);

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
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("DevPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddCors(o => o.AddPolicy("ProdPolicy", builder =>
            {
                builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins("https://*.jokes.domain")
                    .Build();
            }));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
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
        }
    }
}