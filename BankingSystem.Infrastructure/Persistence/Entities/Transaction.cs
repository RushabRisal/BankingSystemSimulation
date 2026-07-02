using System;
using System.Collections.Generic;

namespace BankingSystem.Infrastructure.Persistence.Entities;

public partial class Transaction
{
    public Guid Id { get; set; }

    public string ReferenceNumber { get; set; } = null!;

    public Guid? FromAccountId { get; set; }

    public Guid? ToAccountId { get; set; }

    public decimal Amount { get; set; }

    public string TransactionType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BankAccount? FromAccount { get; set; }

    public virtual BankAccount? ToAccount { get; set; }
}
