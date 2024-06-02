using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test_Api.Helper;
using Test_Api.Helper.Enums;

namespace Test_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpPost("Admin")]
        [AuthorizeRoles(RoleType.Admin)]

        public async Task<IActionResult> AdminGameBoard()
        {
            return Ok("admin permission");
        }

        [HttpPost]
        [AuthorizeRoles(RoleType.Player)]
        public async Task<IActionResult> PlayerGameBoard()
        {
            return Ok("plyare permission");
        }

        [HttpPost("guest")]
        [AllowAnonymous]
        public async Task<IActionResult> GameBoard()
        {
            return Ok("any one can access");
        }

    }
}
