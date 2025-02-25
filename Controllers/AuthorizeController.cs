using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagementSystem.Models;


namespace TaskManagementSystem.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<AppUser> _siginManager;
        public AuthorizeController(IConfiguration configuration, SignInManager<AppUser> siginManager)
        {
            _configuration = configuration;
            _siginManager = siginManager;
        }
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginUser user)
        {
            var res = await _siginManager.PasswordSignInAsync(user.username, user.password, true, false);
            if (res.Succeeded)
            {
                //generate token
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokendesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim("SessionExpired", DateTime.Now.AddMinutes(60).ToString("o")),
                        new Claim(JwtRegisteredClaimNames.Email, user.username)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(3000),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenhandler.CreateToken(tokendesc);
                var finaltoken = tokenhandler.WriteToken(token);
                return Ok(new TokenResponse() {code = "001",username = user.username, Token = finaltoken, RefreshToken = "" });

            }
            else
            {
                Console.WriteLine("Login failed: " + res.ToString());
                return Unauthorized();
            }

        }
    }
}