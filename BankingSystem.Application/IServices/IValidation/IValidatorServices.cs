
namespace BankingSystem.Application.IServices.IValidation
{
    public interface IValidatorServices
    {
        Task<bool> IsValidEmail(string Email);
    }
}
