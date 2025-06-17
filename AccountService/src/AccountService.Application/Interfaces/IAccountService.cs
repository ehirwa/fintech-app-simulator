using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Application.DTOs;

namespace AccountService.Application.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAsync(AccountDto account);
        Task<AccountDto?> GetAsync(Guid id);
        Task<List<AccountDto>> SearchAsync(string ownerName);
        Task UpdateAsync(AccountDto account);
        Task DeleteAsync(Guid id);
    }
}
