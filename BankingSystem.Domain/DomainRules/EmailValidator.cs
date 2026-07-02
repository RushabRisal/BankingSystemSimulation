

using BankingSystem.Domain.DomainException;
using BankingSystem.Domain.DomainRules.IDomain;
using DnsClient;
using DnsClient.Protocol;
using System.Net.Mail;

namespace BankingSystem.Domain.DomainRules
{
    public class EmailValidator : IEmailValidator
    {
        private async Task<bool> DnsCheck(string domain)
        {
            var options = new LookupClientOptions
            {
                Timeout = TimeSpan.FromSeconds(12)
            };
            var lookup = new LookupClient(options);

            IDnsQueryResponse result = await lookup.QueryAsync(domain, QueryType.MX).ConfigureAwait(false);
            return result.Answers.Any(record =>
                record.RecordType == ResourceRecordType.A || record.RecordType == ResourceRecordType.AAAA ||
                record.RecordType == ResourceRecordType.MX
            );
        }
        public async Task<bool> IsEmailValid(string Email)
        {
            var mailAddress = new MailAddress(Email);
            var res = await DnsCheck(mailAddress.Host);
            if (!res)
            {
                throw new InvalidEmailFormat("The Email is not it standard format");
            }
            return res;
        }
    }
}
