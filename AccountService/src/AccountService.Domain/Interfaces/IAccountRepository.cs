using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Domain.Entities;

namespace AccountService.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<List<Account>> SearchAsync(string ownerName);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid id);
    }
}
