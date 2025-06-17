using System;

namespace AccountService.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
