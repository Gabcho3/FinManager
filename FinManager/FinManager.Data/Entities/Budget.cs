using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using FinManager.Common.DataConstants;

namespace FinManager.Data.Entities
{
    public class Budget
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Length(0, 30)]
        public string Name { set; get; } = null!;

        [Length(0, 250)]
        public string? Description { get; set; }

        [Required]
        [Range(AmountConstants.AmountMin, AmountConstants.AmountMax)]
        [Precision(AmountConstants.AmountPrecision, AmountConstants.AmountScale)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<BudgetTransaction> BudgetsTransactions => new List<BudgetTransaction>();

        //[Required]
        //public Guid CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; } = null!;

    }
}
