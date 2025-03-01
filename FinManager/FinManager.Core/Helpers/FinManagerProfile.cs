using AutoMapper;

using FinManager.Core.Models.Transactions;
using FinManager.Data.Entities;

namespace FinManager.Core.Helpers
{
    public class FinManagerProfile : Profile
    {
        public FinManagerProfile()
        {
            //Transaction
            CreateMap<TransactionFormModel, Transaction>();
        }
    }
}
