using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Test_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GameBoard()
        {
            return ("admin permission")
        }

        [HttpPost]
        [Authorize(Policy = "player")]
        public async Task<IActionResult> GameBoard()
        {
            return ("plyare permission")
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GameBoard()
        {
            return ("any one can access");
        }

    }
