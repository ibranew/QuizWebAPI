using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizWebAPI.Application.Abstractions.Handlers;
using QuizWebAPI.Application.DTOs;
using QuizWepAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Infrastructure.Concretes.Handlers
{
    public class TokenHandler : ITokenHandler
    {

        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(int lifeTimeMinute, AppUser user)
        {
            // Token bilgilerini tutacak nesne oluşturuluyor.
            Token token = new();

            // SecurityKey kontrolü yapılıyor.
            string? securityKeyConfig = _configuration["Token:SecurityKey"];
            if (string.IsNullOrEmpty(securityKeyConfig))
            {
                throw new Exception("Token:SecurityKey is not exist");
            }

            // Güvenlik anahtarı oluşturuluyor.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(securityKeyConfig));

            // Token'ı imzalamak için gerekli bilgiler hazırlanıyor.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Token ayarları yapılandırılıyor.
            token.Expiration = DateTime.UtcNow.AddMinutes(lifeTimeMinute); // Token süresi ayarlanıyor.
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"], // Token'ın hangi istemciler için geçerli olduğu
                issuer: _configuration["Token:Issuer"],   // Token'ı oluşturan sunucu bilgisi
                expires: token.Expiration,               // Token geçerlilik süresi
                notBefore: DateTime.UtcNow,              // Token ne zaman kullanılabilir
                signingCredentials: signingCredentials, // İmzalama bilgileri
                claims: new List<Claim>                 // Kullanıcı bilgileri ekleniyor
                {
                       new(ClaimTypes.Name, string.IsNullOrEmpty(user.UserName) ? "Unknown" : user.UserName)
                }
            );

            // Token oluşturucu ile erişim token'ı oluşturuluyor.
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            // Yenileme token'ı oluşturuluyor.
            // token.RefreshToken = CreateRefreshToken();

            // Token nesnesi döndürülüyor.
            return token;
        }

    }
}
