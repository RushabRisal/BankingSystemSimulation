namespace BankingSystem.Domain.DomainRules.EmailValidator
{
    public interface IEmailValidator
    {
        Task<bool> IsEmailValid(string Email);
    }
}
