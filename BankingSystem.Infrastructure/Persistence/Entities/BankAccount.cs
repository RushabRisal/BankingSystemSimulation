using System;
using System.Collections.Generic;

namespace BankingSystem.Infrastructure.Persistence.Entities;

public partial class BankAccount
{
    public Guid Id { get; set; }

    public string AccountNumber { get; set; } = null!;

    public Guid UserId { get; set; }

    public string AccountType { get; set; } = null!;

    public decimal Balance { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AccountFreezeHistory> AccountFreezeHistories { get; set; } = new List<AccountFreezeHistory>();

    public virtual ICollection<Beneficiary> BeneficiaryBeneficiaryAccounts { get; set; } = new List<Beneficiary>();

    public virtual ICollection<Beneficiary> BeneficiaryOwnerAccounts { get; set; } = new List<Beneficiary>();

    public virtual ICollection<Transaction> TransactionFromAccounts { get; set; } = new List<Transaction>();

    public virtual ICollection<Transaction> TransactionToAccounts { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
