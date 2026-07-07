

namespace BankingSystem.Domain.DomainException
{
    public abstract class EmailException(string Message, int statusCode) : Exception(Message)
    {
        public int StatusCode { get; set; } = statusCode;
    }
}
