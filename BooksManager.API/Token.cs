
using BooksManager.Infrastructure.Entities;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace BooksManager.API
{
    public class Token
    {
        public string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("HERE$IS$THE$SECRET");
            var handler = new JwtSecurityTokenHandler();
            var token = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(1),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                })
            };
            var generatedToken = handler.WriteToken(handler.CreateToken(token));
            Console.WriteLine("Token gerado: " + generatedToken);
            Console.WriteLine("Email: " + user.Email);
            return generatedToken;
        }
    }
}
