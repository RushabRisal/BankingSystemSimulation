
using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Domain.Models;

namespace BankingSystem.Application.IRepository.IQuery.IAuthentication
{
    public interface IUserRepository
    {
        Task<T?> GetUserCredentialByEmail<T>(string Email);
        Task<UserModel?> VerifyUserRefreshToken(string refreshToken);
    }
}
