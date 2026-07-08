

using BankingSystem.Application.IServices.ISecurity;
using BankingSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BankingSystem.Application.Services.Security
{
    public class CryptoServices(PasswordHasher<UserModel> hasher) : ICryptoService
    {
        private readonly PasswordHasher<UserModel> _hasher = hasher;

        public string GenerateHasPassword(UserModel user, string password)
        {
            return _hasher.HashPassword(user: user, password: password);
        }

        public bool IsPasswordValid(UserModel user, string hashedPassword, string toBeComparedPassword)
        {
            PasswordVerificationResult result = _hasher.VerifyHashedPassword(user: null!, hashedPassword: hashedPassword, providedPassword: toBeComparedPassword);
            if (result == PasswordVerificationResult.Failed) return false;
            return true;
        }
    }
}
