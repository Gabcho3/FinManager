using AutoMapper;
using FinManager.Core.Contracts;
using FinManager.Core.Models.Budget;
using FinManager.Data;
using FinManager.Data.Entities;

namespace FinManager.Core.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly FinManagerDbContext context;
        private readonly IMapper mapper;

        public BudgetService(FinManagerDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task AddBudgetAsync(BudgetFormModel formModel)
        {
            var budgetToAdd = mapper.Map<Budget>(formModel);

            await context.AddAsync(budgetToAdd);
            await context.SaveChangesAsync();
        }
    }
}
