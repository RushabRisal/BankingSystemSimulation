

namespace BankingSystem.Application.IRepository.ICommand.IAuthentication
{
    public interface IRegisterCommand
    {
        Task<bool> RegisterUserCommand();
    }
}
