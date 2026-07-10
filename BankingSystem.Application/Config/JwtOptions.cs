

namespace BankingSystem.Application.Config
{
    public sealed class JwtOptions
    {
        public string Audience { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Key { get; init; } = string.Empty;
        public int LifeSpanInMinutes { get; init; }
    }
}
