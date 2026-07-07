

using BankingSystem.Domain.DomainException;
using BankingSystem.Domain.DomainRules.EmailValidator;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BankingSystem.Domain.Models
{
    public class UserModel
    {
        private readonly static IEmailValidator _validator = new EmailValidator();
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Contact { get; set; }
        public required string PasswordHash { get; set; }
        public required string Role { get; set; }
        [SetsRequiredMembers]
        public UserModel(
string FirstName,
            string MiddleName,
            string LastName,
            string Contact,
            string Email,
            string PasswordHash,
            string Role
        )
        {
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = IsEmailValid(Email);
            
            this.Contact = Contact;
            this.PasswordHash = PasswordHash;
            this.Role = Role;
        }
        private static string IsEmailValid(string Email)
        {
            if (!_validator.IsEmailValid(Email).Result)
            {
                throw new InvalidEmailFormat("The format of Email is not in Standard");
            }
            return Email;
        }
    }
}
