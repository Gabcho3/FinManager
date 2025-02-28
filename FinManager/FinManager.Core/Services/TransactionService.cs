using AutoMapper;

using FinManager.Core.Contracts;
using FinManager.Core.Models.Transactions;
using FinManager.Data;
using FinManager.Data.Entities;

namespace FinManager.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly FinManagerDbContext context;
        private readonly IMapper mapper;

        public TransactionService(FinManagerDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public async Task AddTransactionAsync(TransactionFormModel transactionFormModel)
        {
            var transactionToAdd = mapper.Map<Transaction>(transactionFormModel);

            await context.AddAsync(transactionToAdd);
            await context.SaveChangesAsync();
        }
        
        public Task EditTransactionAsync(Guid transactionId, TransactionFormModel transactionFormModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTransactionAsync(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        
    }
}
