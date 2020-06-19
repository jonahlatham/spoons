using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using spoons.Data;
using spoons.Data.Entities;

namespace JWTAuthenticationExample.Controllers
{
    [ApiController]
    [Route ("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private CoreContext _context;
        public AuthenticationController (IConfiguration config, CoreContext context)
        {
            _config = config;
            _context = context;
        }

        User AuthenticateUser (User loginCredentials)
        {
            User user = _context.User.SingleOrDefault (x => x.Email == loginCredentials.Email && x.Password == loginCredentials.Password);
            return user;
        }

        void RegisterUser (User registerCredentials)
        {
            User user = _context.User.SingleOrDefault (x => x.Email == registerCredentials.Email);
            if (user == null)
            {
                _context.User.Add (new User () { Username = registerCredentials.Username, Email = registerCredentials.Email, Password = registerCredentials.Password });
                _context.SaveChanges ();
            }
            else
            {
                throw new System.ArgumentException ("This Email is already in use. Please login.");
            }
        }

        [HttpPost ("login")]
        [AllowAnonymous]
        public IActionResult Login ([FromBody] User login)
        {
            IActionResult response = Unauthorized ();
            User user = AuthenticateUser (login);
            if (user != null)
            {
                var tokenString = GenerateJWTToken (user);
                response = Ok (new
                {
                    token = tokenString,
                        userDetails = user,
                });
            }
            return response;
        }

        [HttpPost ("register")]
        [AllowAnonymous]
        public IActionResult Register ([FromBody] User register)
        {
            IActionResult response = Unauthorized ();
            RegisterUser (register);
            User user = AuthenticateUser (register);
            if (user != null)
            {
                var tokenString = GenerateJWTToken (user);
                response = Ok (new
                {
                    token = tokenString,
                        userDetails = user
                });
            }
            return response;
        }

        string GenerateJWTToken (User userInfo)
        {
            var securityKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials (securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new []
            {
                new Claim (JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim ("UserId", userInfo.Id.ToString ()),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
            };
            var token = new JwtSecurityToken (
                issuer: _config["Jwt:Issuer"],
                audience : _config["Jwt:Audience"],
                claims : claims,
                expires : DateTime.Now.AddHours (24),
                signingCredentials : credentials
            );
            return new JwtSecurityTokenHandler ().WriteToken (token);
        }
    }
}