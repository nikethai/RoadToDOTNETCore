using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoadToAPI.Auth;
using RoadToAPI.Model;

namespace RoadToAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyOrigin")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        AuthToken auth;

        public AuthController(IConfiguration config)
        {
            auth = new AuthToken(config);
        }

        [HttpGet]
        [Authorize()]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]Users login)
        {
            var user = auth.getAuthenticate(login);
            var tokenString = "";

            if (user != null)
            {
                tokenString = auth.getToken(user);
            }
            if (tokenString != "")
            {
                Response.Headers.Add("Authorization", tokenString);
                return Ok();
            }
            return Unauthorized();
        }

    }
}