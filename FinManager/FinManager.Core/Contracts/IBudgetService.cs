using FinManager.Core.Models.Budget;

namespace FinManager.Core.Contracts
{
    public interface IBudgetService
    {
        Task AddBudgetAsync(BudgetFormModel formModel);
    }
}
