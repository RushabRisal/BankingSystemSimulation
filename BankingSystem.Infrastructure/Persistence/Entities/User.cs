using BankingSystem.Domain.Models;
using System;
using System.Collections.Generic;

namespace BankingSystem.Infrastructure.Persistence.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? ExpireAt { get; set; }

    public virtual ICollection<AccountFreezeHistory> AccountFreezeHistories { get; set; } = new List<AccountFreezeHistory>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();

}
