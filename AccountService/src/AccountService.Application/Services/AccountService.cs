using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Application.DTOs;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;

namespace AccountService.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<AccountDto> CreateAsync(AccountDto accountDto)
        {
            var entity = new Account
            {
                Id = Guid.NewGuid(),
                OwnerName = accountDto.OwnerName,
                Currency = accountDto.Currency,
                Balance = accountDto.Balance,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.AddAsync(entity);

            accountDto.Id = entity.Id;
            return accountDto;
        }

        public async Task<AccountDto?> GetAsync(Guid id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;
            return new AccountDto
            {
                Id = entity.Id,
                OwnerName = entity.OwnerName,
                Currency = entity.Currency,
                Balance = entity.Balance
            };
        }

        public async Task<List<AccountDto>> SearchAsync(string ownerName)
        {
            var accounts = await _repo.SearchAsync(ownerName);
            var list = new List<AccountDto>();
            foreach (var acc in accounts)
            {
                list.Add(new AccountDto
                {
                    Id = acc.Id,
                    OwnerName = acc.OwnerName,
                    Currency = acc.Currency,
                    Balance = acc.Balance
                });
            }
            return list;
        }

        public async Task UpdateAsync(AccountDto account)
        {
            var entity = await _repo.GetByIdAsync(account.Id);
            if (entity == null) return;
            entity.OwnerName = account.OwnerName;
            entity.Currency = account.Currency;
            entity.Balance = account.Balance;
            await _repo.UpdateAsync(entity);
        }

        public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
    }
}
