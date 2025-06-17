using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Domain;

namespace AccountService.Application
{
    /// <summary>
    /// Application service containing business logic for account management.
    /// </summary>
    public class AccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task<Account?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task<IEnumerable<Account>> GetByUserAsync(Guid userId) => _repository.GetByUserAsync(userId);

        public async Task<Account> CreateAsync(Guid userId, Currency currency)
        {
            var account = new Account
            {
                UserId = userId,
                Currency = currency,
                Balance = 0m
            };
            await _repository.AddAsync(account);
            return account;
        }

        public Task UpdateAsync(Account account) => _repository.UpdateAsync(account);

        public Task DeleteAsync(Account account) => _repository.DeleteAsync(account);
    }
}
