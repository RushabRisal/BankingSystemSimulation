
using BankingSystem.Application.Config;
using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IServices.ISecurity;
using BankingSystem.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BankingSystem.Application.Services.AuthenticationServices
{
    public class JwtServices : IJwtServices
    {
        private readonly JwtOptions _options;
        private readonly ILoginCommandRepository _login;
        public JwtServices(IOptions<JwtOptions> options, ILoginCommandRepository loginRepo)
        {
            _options = options.Value;
            _login = loginRepo;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[32];
            using var generateRng = RandomNumberGenerator.Create();
            generateRng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public async Task<string> SaveAndReturnRefreshToken(string Email)
        {
            var refreshToken = GenerateRefreshToken();
            var resp = await _login.SaveRefreshTokenCommand(refreshToken, Email);
            if (!resp) throw new Exception("Invalid Request");
            return refreshToken;
        }
        private string GetJwtClaims(UserModel user)
        {
            //create signing key
            var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.Key)
                );
            var claim = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new(ClaimTypes.Role, user.Role)
            };
            var issuer = _options.Issuer;
            var audience = _options.Audience;
            var lifeSpan = _options.LifeSpanInMinutes;
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claim,
                    signingCredentials: cred,
                    expires: DateTime.UtcNow.AddMinutes(lifeSpan)
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public async Task<TokenResponse> CreateTokens(UserModel user)
        {
            return new TokenResponse
            {
                AccessToken = GetJwtClaims(user),
                RefreshToken = await SaveAndReturnRefreshToken(user.Email)
            };
        }
    }
}
