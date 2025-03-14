﻿using AutoMapper;

using FinManager.Core.Models.Budget;
using FinManager.Core.Models.Transaction;
using FinManager.Data.Entities;

namespace FinManager.Core.Helpers
{
    public class FinManagerProfile : Profile
    {
        public FinManagerProfile()
        {
            //Transaction
            CreateMap<TransactionFormModel, Transaction>();
            CreateMap<Transaction, TransactionViewModel>();

            //Budget
            CreateMap<BudgetFormModel, Budget>();
            CreateMap<Budget, BudgetViewModel>();
        }
    }
}
