using BankingSystem.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Infrastructure.Persistence;

public partial class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
{

    public virtual DbSet<AccountFreezeHistory> AccountFreezeHistories { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<Beneficiary> Beneficiaries { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountFreezeHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountF__3214EC071F45F69D");

            entity.ToTable("AccountFreezeHistory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.FrozenAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.AccountFreezeHistories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountFreezeHistory_Account");

            entity.HasOne(d => d.FrozenByUser).WithMany(p => p.AccountFreezeHistories)
                .HasForeignKey(d => d.FrozenByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountFreezeHistory_FrozenBy");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC07DDD8DE41");

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EntityName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLogs_Users");
        });

        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankAcco__3214EC07B385DF4F");

            entity.HasIndex(e => e.AccountNumber, "UQ__BankAcco__BE2ACD6FC20BA6D8").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.AccountNumber).HasMaxLength(20);
            entity.Property(e => e.AccountType).HasMaxLength(10);
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active");

            entity.HasOne(d => d.User).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_BankAccounts_Users");
        });

        modelBuilder.Entity<Beneficiary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Benefici__3214EC07DD7A0FCF");

            entity.HasIndex(e => new { e.OwnerAccountId, e.BeneficiaryAccountId }, "UQ_Beneficiary").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Nickname).HasMaxLength(50);

            entity.HasOne(d => d.BeneficiaryAccount).WithMany(p => p.BeneficiaryBeneficiaryAccounts)
                .HasForeignKey(d => d.BeneficiaryAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiaries_BeneficiaryAccount");

            entity.HasOne(d => d.OwnerAccount).WithMany(p => p.BeneficiaryOwnerAccounts)
                .HasForeignKey(d => d.OwnerAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Beneficiaries_OwnerAccount");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC072CF48D41");

            entity.HasIndex(e => e.ReferenceNumber, "UQ__Transact__C5ADBE4D1D9C4DB9").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ReferenceNumber).HasMaxLength(30);
            entity.Property(e => e.Remarks).HasMaxLength(100);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionType).HasMaxLength(10);

            entity.HasOne(d => d.FromAccount).WithMany(p => p.TransactionFromAccounts)
                .HasForeignKey(d => d.FromAccountId)
                .HasConstraintName("FK_Transactions_FromAccount");

            entity.HasOne(d => d.ToAccount).WithMany(p => p.TransactionToAccounts)
                .HasForeignKey(d => d.ToAccountId)
                .HasConstraintName("FK_Transactions_ToAccount");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0723F29A0B");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534476A3F38").IsUnique();

            entity.HasIndex(e => e.Contact, "UQ__Users__F7C046652AB5F6E2").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Contact).HasMaxLength(15);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.MiddleName).HasMaxLength(20);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.RefreshToken).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
