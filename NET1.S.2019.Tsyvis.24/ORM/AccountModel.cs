namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Configuration;

    public partial class AccountModel : DbContext
    {
        public AccountModel()
            : base("name=AccountModel")
        {
        }

        public virtual DbSet<AccountOwner> AccountOwners { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountOwner>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountOwner)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Account>()
                .Property(e => e.BonusPoints)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AccountType>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<AccountType>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.AccountType)
                .WillCascadeOnDelete(false);
        }
    }
}
