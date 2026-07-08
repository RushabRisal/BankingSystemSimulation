

using System.Net;

namespace BankingSystem.Infrastructure.InfraExceptionHandler
{
    public sealed class IncorrectConnectionStringException(string Message) : HeadExceptionHandler(Message: Message, StatusCode: (int)HttpStatusCode.InternalServerError);

    public sealed class PasswordDoesnotExistException (string Message) : HeadExceptionHandler(Message:Message, StatusCode: (int)HttpStatusCode.NotFound);
}
