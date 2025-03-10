using FinManager.Common.DataConstants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FinManager.Core.Models.Budget
{
    public class BudgetFormModel
    {
        public Guid Id { get; set; }

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
    }
}
