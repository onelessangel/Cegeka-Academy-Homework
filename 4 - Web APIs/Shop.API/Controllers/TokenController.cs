using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ShopContext _context;
        private IConfiguration _configuration;

        public TokenController(ShopContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = _context.Users.ToArrayAsync();
            return Ok(users);
        }

        [HttpPost]
        public ActionResult CreateToken(User user)
        {
            var userToCheck = _context.Users.Find(user.Id);

            // userul nu exista in baza de date
            if (userToCheck == null || userToCheck.UserName != user.UserName || userToCheck.Password != user.Password)
            {
                return BadRequest();
            }

            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                 new Claim("Id", Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti,
                 Guid.NewGuid().ToString())
                 }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return Ok(stringToken);
        }
    }
}
