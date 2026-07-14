using BankingSystem.Application.DTOs.UserDto;
using Microsoft.AspNetCore.Http;

namespace BankingSystem.Application.IServices.IAuthentication
{
    public interface IAuthService
    {
        Task<ResponseRegistryDto> RegisterAsync(RequestRegistryDto user);
        Task<TokenResponse?> LoginAsync(RequestLoginDto user);
        Task<TokenResponse?> RefreshTokenAsync(string refreshToken);
        void SetCookie(TokenResponse request, HttpContext context);
    }
}
