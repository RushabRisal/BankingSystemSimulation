

using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Contact { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
