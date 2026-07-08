using BankingSystem.Application.DTOs.UserDto;

namespace BankingSystem.Application.IServices.IAuthentication
{
    public interface IAuthService
    {
        Task<ResponseRegistryDto> RegisterAsync(RequestRegistryDto user);
        Task<bool> LoginAsync(RequestLoginDto user);
    }
}
