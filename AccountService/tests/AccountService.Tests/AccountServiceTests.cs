using System;
using System.Threading.Tasks;
using AccountService.Application.DTOs;
using AccountService.Application.Services;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Moq;
using Xunit;

namespace AccountService.Tests
{
    public class AccountServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnCreatedAccount()
        {
            var repo = new Mock<IAccountRepository>();
            repo.Setup(r => r.AddAsync(It.IsAny<Account>())).Returns(Task.CompletedTask);

            var service = new AccountService.Application.Services.AccountService(repo.Object);
            var dto = new AccountDto
            {
                OwnerName = "John Doe",
                Currency = "USD",
                Balance = 100m
            };

            var result = await service.CreateAsync(dto);

            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal("John Doe", result.OwnerName);
        }
    }
}
