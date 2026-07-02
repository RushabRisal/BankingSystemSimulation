using System;
using System.Collections.Generic;

namespace BankingSystem.Infrastructure.Persistence.Entities;

public partial class Beneficiary
{
    public Guid Id { get; set; }

    public Guid OwnerAccountId { get; set; }

    public Guid BeneficiaryAccountId { get; set; }

    public string? Nickname { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual BankAccount BeneficiaryAccount { get; set; } = null!;

    public virtual BankAccount OwnerAccount { get; set; } = null!;
}
