

using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Domain.Models;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Persistence.Entities;

namespace BankingSystem.Infrastructure.Repository.Command.AuthRepository
{
    public class RegisterCommand(MyContext context) : IRegisterCommand
    {
        private readonly MyContext _context = context;
        public async Task<bool> RegisterUserCommand(UserModel userData)
        {
            var user = new User
            {
                FirstName = userData.FirstName,
                MiddleName = userData.MiddleName,
                LastName = userData.LastName,
                Email = userData.Email,
                PasswordHash = userData.PasswordHash,
                Contact = userData.Contact,
                Role = userData.Role
            };
            try
            {
                _ = _context.Users.Add(user);
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
