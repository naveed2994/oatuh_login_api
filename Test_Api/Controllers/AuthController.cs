using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test_Api.Helper.Enums;

namespace OAuthLoginApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("Authenticate")]
        /// <summary>
        /// the implementation of the token generation will be in sperate application layer but this is due to lack of time.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Authenticate(Login model)
        {
            List<Claim> claims = new List<Claim>();

            if (model.UserName == "admin" && model.Password == "admin")
            {
                claims.Add(new Claim("roles",
                   "0"));
                claims.Add(new Claim("name",
                    "admin"));

            }
            else if (model.UserName == "player" && model.Password == "player")
            {
                claims.Add(new Claim("roles",
                  "1"));
                claims.Add(new Claim("name",
                   "player"));
            }
            else
            {
                return Unauthorized();
            }


            var secretBytes = Encoding.UTF8.GetBytes("ABx@123232323232323$");
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
            "https://localhost:7000",
                            "https://localhost:7000"
,
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { access_token = tokenJson });
        }

        [HttpPost]
        public IActionResult Decode(string part)
        {
            var bytes = Convert.FromBase64String(part);
            return Ok(Encoding.UTF8.GetString(bytes));
        }

    }
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}