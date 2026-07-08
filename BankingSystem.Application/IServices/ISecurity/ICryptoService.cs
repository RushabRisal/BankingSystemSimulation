

using BankingSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BankingSystem.Application.IServices.ISecurity
{
    public interface ICryptoService
    {
        string GenerateHasPassword(UserModel user, string password);
        bool IsPasswordValid(UserModel user, string hashedPassword, string toBeComparedPassword);
    }
}
