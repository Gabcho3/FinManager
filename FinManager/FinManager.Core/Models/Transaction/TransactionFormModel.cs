using FinManager.Data.Enums;
using System.ComponentModel.DataAnnotations;

using FinManager.Common.DataConstants;

namespace FinManager.Core.Models.Transactions
{
    public class TransactionFormModel
    {
        public Guid Id { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [Range(AmountConstants.AmountMin, AmountConstants.AmountMax)]
        public decimal Amount { get; set; }

        [MaxLength(TransactionConstants.DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid CatagoryId { get; set; }
    }
}
