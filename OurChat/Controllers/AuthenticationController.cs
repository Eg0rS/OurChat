using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OurChat.Models.DomainModels;

namespace OurChat.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Autorization user)
    {
        if (user is null)
        {
            return BadRequest("Invalid user request!!!");
        }

        var tokeOptions = new JwtSecurityToken(
            issuer: _configuration["Tokens:Authenticate:Issuer"],
            audience: _configuration["Tokens:Authenticate:Audience"],
            claims: new List<Claim>(),
            expires: DateTime.Now.AddSeconds(Convert.ToDouble(_configuration["Tokens:Authenticate:Ttl"])),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Authenticate:Secret"])),
                SecurityAlgorithms.HmacSha256)
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return Ok(new JWTResponse { Token = tokenString });
    }
}