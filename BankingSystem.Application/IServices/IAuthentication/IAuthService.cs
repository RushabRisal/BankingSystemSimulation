using BankingSystem.Application.DTOs.UserDto;

namespace BankingSystem.Application.IServices.IAuthentication
{
    public interface IAuthService
    {
        Task<ResponseRegistry> RegisterAsync(RequestRegistry user);
    }
}
