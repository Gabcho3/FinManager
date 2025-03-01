using FinManager.Data.Enums;

namespace FinManager.Core.Models.Transaction
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public DateTime Date { get; set; }
    }
}
