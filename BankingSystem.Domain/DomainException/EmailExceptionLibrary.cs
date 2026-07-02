using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Domain.DomainException
{
    public sealed class InvalidEmailFormat(string Message) : EmailException(Message) { }
}
