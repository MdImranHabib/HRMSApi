using HRMSApi.Models;
using HRMSApi.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly HRMSDBContext _context;
        private readonly IConfiguration _config;      

        public AuthController(HRMSDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;                   
        }      

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.UserName) && !string.IsNullOrWhiteSpace(model.Password))
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

                if (user != null)
                {
                    var token = GenerateJwtToken(user).Result;

                    if (token != null)
                    {
                        return Ok(token);
                    }
                }                
            }

            return Unauthorized();
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (!string.IsNullOrWhiteSpace(user.ResidentId.ToString()))
            {
                claims.Add(new Claim(ClaimTypes.SerialNumber, user.ResidentId.ToString()));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(9),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
