using Microsoft.AspNetCore.Identity;

namespace FinManager.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        public ICollection<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();

        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
