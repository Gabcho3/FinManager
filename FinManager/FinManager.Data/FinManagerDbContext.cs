﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using FinManager.Data.Entities;

namespace FinManager.Data
{
    public class FinManagerDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FinManagerDbContext(DbContextOptions<FinManagerDbContext> options)
            : base(options) { }

        public override DbSet<ApplicationUser> Users {get; set;} = null!;

        public DbSet<Category> Categories { get; set;} = null!;

        public DbSet<Budget> Budgets { get; set;} = null!;

        public DbSet<SavingGoal> SavingGoals { get; set;} = null!;

        public DbSet<Transaction> Transactions { get; set;} = null!;

        public DbSet<BudgetTransaction> BudgetTransactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.SavingGoals)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Budgets)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BudgetTransaction>()
                .HasKey(bt => new { bt.BudgetId, bt.TransactionId });

            builder.Entity<BudgetTransaction>()
                .HasOne(bt => bt.Budget)
                .WithMany(b => b.BudgetsTransactions)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<BudgetTransaction>()
                .HasOne(bt => bt.Transaction)
                .WithMany(t => t.BudgetsTransactions)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }
    }
}
