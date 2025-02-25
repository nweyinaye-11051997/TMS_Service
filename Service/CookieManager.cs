using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskManagementSystem.Service
{
    public class CookieManager
    {
        public void setCookie ()
        {

        //        var issuer = _configuration["Jwt:Issuer"];
        //var audience = _configuration["Jwt:Audience"];
        //var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new[]
        //    {
        //                new Claim("Id", Guid.NewGuid().ToString()),
        //                //new Claim("SessionExpired", DateTime.Now.AddMinutes(15).ToString("o")),
        //                new Claim("SessionExpired", DateTime.Now.AddMinutes(60).ToString("o")),
        //                new Claim(JwtRegisteredClaimNames.Email, user.username),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //            }),
        //    Expires = DateTime.UtcNow.AddMinutes(10),
        //    Issuer = issuer,
        //    Audience = audience,
        //    SigningCredentials = new SigningCredentials
        //    (new SymmetricSecurityKey(key),
        //    SecurityAlgorithms.HmacSha512Signature)
        //};
        //var tokenHandler = new JwtSecurityTokenHandler();
        //var token = tokenHandler.CreateToken(tokenDescriptor);
        //var jwtToken = tokenHandler.WriteToken(token);
        //HttpContext.Response.Headers.
        //("jwt_token", jwtToken);
        //        HttpContext.Response.Cookies.Append("jwt_token", jwtToken, options);
        //        HttpContext.Session.SetString("jwt_token", jwtToken);
        //        var jwt = HttpContext.Session.GetString("jwt_token");
    }
    }
}
