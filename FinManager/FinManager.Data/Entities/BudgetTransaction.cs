using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinManager.Data.Entities
{
    public class BudgetTransaction
    {
        [Required]
        public Guid BudgetId { get; set; }

        [ForeignKey("BudgetId")]
        public Budget Budget { get; set; }

        [Required]
        public Guid TransactionId { get; set; }

        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }
    }
}
