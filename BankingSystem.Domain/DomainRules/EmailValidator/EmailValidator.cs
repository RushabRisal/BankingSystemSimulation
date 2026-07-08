using DnsClient;
using System.Net.Mail;

namespace BankingSystem.Domain.DomainRules.EmailValidator
{
    public class EmailValidator : IEmailValidator
    {
        private static async Task<bool> DnsCheck(string domain)
        {
            var options = new LookupClientOptions
            {
                Timeout = TimeSpan.FromSeconds(3)
            };
            var lookup = new LookupClient(options);

            IDnsQueryResponse result = await lookup.QueryAsync(domain, QueryType.MX).ConfigureAwait(false);
            return result.Answers.Any();
        }
        public async Task<bool> IsEmailValid(string Email)
        {
            var mailAddress = new MailAddress(Email);
            var res = await DnsCheck(mailAddress.Host);
            return res;
        }
    }
}
