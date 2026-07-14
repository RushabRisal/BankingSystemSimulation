using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Repository.Command.AuthRepository
{
    internal class LoginCommand(MyContext _context) : ILoginCommandRepository
    {
        public async Task<bool> SaveRefreshTokenCommand(string refreshToken, string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (user is null) return false;
            user.RefreshToken = refreshToken;
            user.ExpireAt = DateTime.UtcNow.AddDays(7);
            try
            {
                _ = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
