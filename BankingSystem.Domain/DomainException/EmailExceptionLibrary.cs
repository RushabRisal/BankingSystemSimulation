

using System.Net;

namespace BankingSystem.Domain.DomainException
{
    public sealed class InvalidEmailFormat(string Message) : EmailException(Message,(int)HttpStatusCode.BadRequest) { }
}
