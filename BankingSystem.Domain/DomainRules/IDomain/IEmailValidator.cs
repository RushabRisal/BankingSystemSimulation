
namespace BankingSystem.Domain.DomainRules.IDomain
{
    public interface IEmailValidator
    {
        Task<bool> IsEmailValid(string Email);
    }
}
