

namespace BankingSystem.Application.DTOs.UserDto
{
    public record RequestRegistry
    {
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Contact { get; init; }
        public required string Password { get; init; }
        public required string Role { get; init; }
    };
    public record ResponseRegistry
    {
        public required string Email { get; init; }
    }


}


