using AccountService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Accounts");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.OwnerName).IsRequired();
                entity.Property(a => a.Currency).IsRequired();
                entity.Property(a => a.Balance).HasColumnType("decimal(18,2)");
                entity.Property(a => a.CreatedAt);
            });
        }
    }
}
