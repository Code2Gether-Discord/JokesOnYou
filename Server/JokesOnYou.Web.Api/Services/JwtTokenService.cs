using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JokesOnYou.Web.Api.Services
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
        private readonly byte[] _key = Encoding.ASCII.GetBytes("We need to use a Secret Handler here");

        public string GetToken(User user)
        {
            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }), //We can add Roles to this later on.
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }

    }
}
