using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BooksManager.Infrastructure.Entities;

namespace BooksManager.Infrastructure.Services
{
	public class TokenService
    {
        public static byte[] Key()
        {
            return Encoding.ASCII.GetBytes("SECRET$DESENVOLVIMENTO$APP$DOTNET");

        }
        public static string GenerateToken(User user)
        {
            // Responsavel pro criar e escrever o token
            var handler = new JwtSecurityTokenHandler();


            // Define identificações existentes no token
            // Neste exemplo: role + email
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(type: ClaimTypes.Email, value: user.Email));
            //claimsIdentity.AddClaim(new Claim(type: ClaimTypes.Role, value: user.Role));

            // Aqui é onde definimos a assinatura do token
            var signatureCredentials = new SigningCredentials(
                new SymmetricSecurityKey(TokenService.Key()),
                SecurityAlgorithms.HmacSha512Signature
                );

            // Aqui montamos a estrutura do token
            var token = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                SigningCredentials = signatureCredentials,
                Expires = DateTime.Now.AddHours(12)
            };

            return handler.WriteToken(handler.CreateToken(token));

        }
    }
}
