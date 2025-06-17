using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountService.Domain;

namespace AccountService.Infrastructure
{
    /// <summary>
    /// EF Core implementation of the account repository.
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public Task<Account?> GetByIdAsync(Guid id) => _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<IEnumerable<Account>> GetByUserAsync(Guid userId)
        {
            return await _context.Accounts.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Account account)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}
