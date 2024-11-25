using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CMS.API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CMS.API.Repositories.Implementation
{
    public class TokenRepository(IConfiguration configuration) : ITokenRepository
    {
        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
              // Create Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // JWT Security Token Parameters
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Get the credential
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //create a token
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
           
            // Return Token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}