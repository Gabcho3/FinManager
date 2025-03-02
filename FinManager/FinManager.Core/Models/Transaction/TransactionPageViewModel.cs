namespace FinManager.Core.Models.Transaction
{
    public class TransactionPageViewModel
    {
        public IEnumerable<TransactionViewModel>? AllUserTransactions {  get; set; }

        public TransactionViewModel? TransactionViewModel { get; set; }

        public TransactionFormModel? TransactionFormModel { get; set; }
    }
}
