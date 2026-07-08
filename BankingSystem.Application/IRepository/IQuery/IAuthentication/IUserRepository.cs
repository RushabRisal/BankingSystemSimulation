
using BankingSystem.Application.DTOs.UserDto;

namespace BankingSystem.Application.IRepository.IQuery.IAuthentication
{
    public interface IUserRepository
    {
        Task<LoginResponseDto?> GetUserCredentialByEmail(string Email);
    }
}
