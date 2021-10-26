using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ListApi.Models;
using Microsoft.IdentityModel.Tokens;
//using Shop;

namespace ListApi.Authorization;
public static class TokenService
{
  public static string GenerateToken(User user, string secret)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(secret);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new Claim[]
      {
        new Claim(ClaimTypes.Name, user.Name.ToString()),
        //new Claim(ClaimTypes.Role, user.Role.ToString())
      }),
      Expires = DateTime.UtcNow.AddHours(2),
      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);

  }
}