using Microsoft.EntityFrameworkCore;
using AccountService.Domain;

namespace AccountService.Infrastructure
{
    /// <summary>
    /// EF Core database context for AccountService.
    /// </summary>
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
