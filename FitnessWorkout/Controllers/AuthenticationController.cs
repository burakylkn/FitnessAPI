using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Fitness.Entities.Request;
using Swashbuckle.AspNetCore.Annotations;

namespace FitnessWorkout.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _config;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IConfiguration config, ILogger<AuthenticationController> logger)
        {
            _config = config;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerOperation(Summary = "Authorize", Description = "Endpoint For Receiving JWT Tokens")]
        public IActionResult Authorize([FromBody] UserLoginRequest objReq)
        {

            try
            {
                string userName = _config["Application:UserName"];
                string password = _config["Application:Password"];

                if (!(objReq.UserName.ToLower() == userName && objReq.Password == password))
                    return BadRequest("UserName or Password Incorrect!");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, objReq.UserName)
                    }),

                    Expires = DateTime.Now.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
