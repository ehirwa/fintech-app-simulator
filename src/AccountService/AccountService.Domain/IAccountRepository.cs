using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Domain
{
    /// <summary>
    /// Repository abstraction for account persistence.
    /// </summary>
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<IEnumerable<Account>> GetByUserAsync(Guid userId);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Account account);
    }
}
