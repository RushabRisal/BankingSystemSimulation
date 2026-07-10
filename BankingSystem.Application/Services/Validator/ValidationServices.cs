

using BankingSystem.Application.IServices.IValidation;
using DnsClient;
using System.Net.Mail;

namespace BankingSystem.Application.Services.Validator
{
    public class ValidationServices : IValidatorServices
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
        public Task<bool> IsValidEmail(string Email)
        {
            var mailAddress = new MailAddress(Email);
            var res = DnsCheck(mailAddress.Host);
            return res;
        }
    }
}
