

using BankingSystem.Domain.Models;

namespace BankingSystem.Application.IRepository.ICommand.IAuthentication
{
    public interface IRegisterCommand
    {
        Task<bool> RegisterUserCommand(UserModel userData);
    }
}
