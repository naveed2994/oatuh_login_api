//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Test_Api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//    };

//        private readonly ILogger<WeatherForecastController> _logger;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return Ok();
//        }

//        [Authorize]
//        public IActionResult Secret()
//        {
//            return Ok();
//        }

//        public IActionResult Authenticate()
//        {
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
//                new Claim("granny", "cookie")
//            };

//            var secretBytes = Encoding.UTF8.GetBytes("123");
//            var key = new SymmetricSecurityKey(secretBytes);
//            var algorithm = SecurityAlgorithms.HmacSha256;

//            var signingCredentials = new SigningCredentials(key, algorithm);

//            var token = new JwtSecurityToken(
//                "https://localhost:7000",
//                "*",
//                claims,
//                notBefore: DateTime.Now,
//                expires: DateTime.Now.AddHours(1),
//                signingCredentials);

//            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

//            return Ok(new { access_token = tokenJson });
//        }

//        public IActionResult Decode(string part)
//        {
//            var bytes = Convert.FromBase64String(part);
//            return Ok(Encoding.UTF8.GetString(bytes));
//        }
//    }
//}