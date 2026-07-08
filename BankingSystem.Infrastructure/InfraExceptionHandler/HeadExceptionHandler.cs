

namespace BankingSystem.Infrastructure.InfraExceptionHandler
{
    public abstract class HeadExceptionHandler(string Message, int StatusCode) : Exception(Message)
    {
        public int StatusCode { get; set; } = StatusCode;
    }
}
