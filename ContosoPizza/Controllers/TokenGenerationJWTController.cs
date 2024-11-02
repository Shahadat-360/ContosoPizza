using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ContosoPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TokenGenerationJWTController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TokenGenerationJWTController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name ="TokenGenerate")]
        public IActionResult GenerateToken()
        {
            var SecretKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:SecretKey"]));
            var Credentials = new 
                SigningCredentials(SecretKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["jwt:IsUser"],
                audience: _configuration["jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: Credentials
            );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
