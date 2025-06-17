using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountService.Application;
using AccountService.Domain;
using Moq;
using Xunit;

namespace AccountService.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnAccountWithZeroBalance()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(r => r.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);
            var service = new AccountService.Application.AccountService(repo.Object);
            var userId = Guid.NewGuid();
            var account = await service.CreateAsync(userId, Currency.USD);
            Assert.Equal(userId, account.UserId);
            Assert.Equal(0m, account.Balance);
        }
    }
}
