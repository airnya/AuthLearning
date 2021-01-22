using AuthLearning.Api.Models;
using AuthLearning.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthLearning.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IOptions<AuthOptions> authOptions;
        public AuthController( IOptions<AuthOptions> options)
        {
            this.authOptions = options;
        }

        //Some mock data, before db 
        private List<Account> Accounts => new List<Account>
        {
            new Account()
            {
                Id = Guid.Parse("b1754c14-d296-4b0f-a09a-030017f4461f"),
                Email = "user@email.com",
                Password = "user",
                Roles = new Role[] { Role.User }
            },
            new Account()
            {
                Id = Guid.Parse("b1754c14-d296-4b0f-a09a-030017f4422f"),
                Email = "admin@email.com",
                Password = "admin",
                Roles = new Role[] { Role.Admin }
            },
        };

        [Route("login")]
        [HttpPost]
        public IActionResult Login ([FromBody]Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if ( user != null )
            {
                var token = GenerateJWT(user);

                return Ok(new { access_token = token });
            }

            return Unauthorized();

        }

        private Account AuthenticateUser(string email, string password)
        {
            return Accounts.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        private string GenerateJWT(Account user)
        {
            var authparams = authOptions.Value;

            var securityKey = authparams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim("role", role.ToString()));
            }

            var token = new JwtSecurityToken(authparams.Issuer, 
                authparams.Audience, 
                claims,
                expires: DateTime.Now.AddSeconds(authparams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
