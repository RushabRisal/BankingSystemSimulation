
using System.Net;

namespace BankingSystem.Application.DTOs
{
    public abstract class ExceptionCarrier(string Message, int StatusCode) : Exception(Message)
    {
        public readonly int StatusCode = StatusCode;
    }
    public sealed class IvalidEmailFormat(string Message) : ExceptionCarrier(Message: Message,
        StatusCode: (int)HttpStatusCode.BadRequest);
}
