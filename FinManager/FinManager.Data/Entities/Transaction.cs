using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using FinManager.Data.Enums;
using FinManager.Common.DataConstants;

namespace FinManager.Data.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Range(AmountConstants.AmountMin, AmountConstants.AmountMax)]
        [Precision(AmountConstants.AmountPrecision, AmountConstants.AmountScale)]
        public decimal Amount { get; set; }

        [MaxLength(TransactionConstants.DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public Guid CatagoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
