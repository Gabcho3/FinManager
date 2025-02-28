using FinManager.Core.Models.Transactions;

namespace FinManager.Core.Contracts
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(TransactionFormModel transactionFormModel);

        Task EditTransactionAsync(Guid transactionId, TransactionFormModel transactionFormModel);

        Task DeleteTransactionAsync(Guid transactionId);
    }
}
