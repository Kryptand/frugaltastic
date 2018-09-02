using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CrossCutting.Authentication.Config;
using CrossCutting.Authentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace CrossCutting.Authentication.Logic
{
    public class JwtUtility
    {

        public static JwtSecurityToken BuildToken(ApplicationUserModel user,string apiSecurityKey, JwtSettings jwtSettings)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apiSecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.AuthenticationModel.UserIdentification),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,new DateTime().ToString(CultureInfo.CurrentCulture)),
                new Claim("Tenant",jwtSettings.Tenant)
            };

            var token = new JwtSecurityToken(jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(jwtSettings.ExpirationTime),
                notBefore:jwtSettings.NotBefore,
                signingCredentials: creds);

            return token;
        }


    }
}
