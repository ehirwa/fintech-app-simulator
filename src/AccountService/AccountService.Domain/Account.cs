using System;

namespace AccountService.Domain
{
    /// <summary>
    /// Represents a bank account for a user.
    /// </summary>
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
    }

    /// <summary>
    /// Supported currencies for an account.
    /// </summary>
    public enum Currency
    {
        USD,
        EUR,
        RWF
    }
}
