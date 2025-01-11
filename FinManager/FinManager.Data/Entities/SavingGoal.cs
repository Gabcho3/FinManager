using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using FinManager.Common.DataConstants;

namespace FinManager.Data.Entities
{
    public class SavingGoal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(SavingGoalsConstants.NameMaxLength)]
        public string GoalName { get; set; } = null!;

        [Required]
        [Range(AmountConstants.AmountMin, AmountConstants.AmountMax)]
        [Precision(AmountConstants.AmountPrecision, AmountConstants.AmountScale)]
        public decimal TargetAmount { get; set; }

        [Required]
        [Range(AmountConstants.AmountMin, AmountConstants.AmountMax)]
        [Precision(AmountConstants.AmountPrecision, AmountConstants.AmountScale)]
        public decimal SavedAmount { get; set; }
                             
        public DateTime? DeadLine { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;
    }
}
