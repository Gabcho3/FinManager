using System.ComponentModel.DataAnnotations;

using FinManager.Common.DataConstants;

namespace FinManager.Data.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(CategoryConstants.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public bool IsExpense { get; set; }
    }
}
