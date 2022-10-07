﻿
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
    [HttpPost("login")]
    public IActionResult Login([FromBody] Autorization user)
    {
        if (user is null)
        {
            return BadRequest("Invalid user request!!!");
        }
        if (user.Login == "Jaydeep" && user.Password == "Pass@777")
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new JWTResponse { Token = tokenString });
        }
        return Unauthorized();
    }
}