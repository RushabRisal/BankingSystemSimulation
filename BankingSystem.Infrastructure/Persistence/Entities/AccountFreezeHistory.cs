using System;
using System.Collections.Generic;

namespace BankingSystem.Infrastructure.Persistence.Entities;

public partial class AccountFreezeHistory
{
    public Guid Id { get; set; }

    public Guid AccountId { get; set; }

    public string Reason { get; set; } = null!;

    public Guid FrozenByUserId { get; set; }

    public DateTime FrozenAt { get; set; }

    public DateTime? UnfrozenAt { get; set; }

    public virtual BankAccount Account { get; set; } = null!;

    public virtual User FrozenByUser { get; set; } = null!;
}
