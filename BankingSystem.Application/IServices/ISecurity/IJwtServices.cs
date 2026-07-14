using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Domain.Models;

namespace BankingSystem.Application.IServices.ISecurity
{
    public interface IJwtServices
    {
        Task<TokenResponse> CreateTokens(UserModel user);
    }
}
