using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AccountService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _db;

        public AccountRepository(AccountDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Account account)
        {
            _db.Accounts.Add(account);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _db.Accounts.FindAsync(id);
            if (entity == null) return;
            _db.Accounts.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Account?> GetByIdAsync(Guid id) =>
            await _db.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<Account>> SearchAsync(string ownerName)
        {
            return await _db.Accounts.AsNoTracking()
                .Where(a => a.OwnerName.Contains(ownerName))
                .ToListAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _db.Accounts.Update(account);
            await _db.SaveChangesAsync();
        }
    }
}
