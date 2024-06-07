using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [Authorize(Policy = "admin")]
        [HttpPost("Admin")]

        public async Task<IActionResult> AdminGameBoard()
        {
            return Ok("admin permission");
        }

        [Authorize(Policy = "player")]
        [HttpPost("Player")]
        public async Task<IActionResult> PlayerGameBoard()
        {
            return Ok("player permission");
        }

        [HttpPost("guest")]
        [AllowAnonymous]
        public async Task<IActionResult> GameBoard()
        {
            return Ok("any one can access");
        }
    }
}
