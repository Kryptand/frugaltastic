using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossCutting.Balance.Models;
using Microsoft.EntityFrameworkCore;

namespace BalanceService.Domain.Database
{
    public class AccountServiceDbContext : DbContext
    {
        public AccountServiceDbContext(DbContextOptions<AccountServiceDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .HasKey(c => new { c.BankAccountGuid, c.TenantGuid,c.UserGuid });
            modelBuilder.Entity<Transaction>()
                .HasKey(c => new { c.TransactionGuid, c.BankAccountGuid });
        }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<ExpenditureType> ExpenditureTypes { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeType> IncomeTypes { get; set; }
        public DbSet<RecurringExpenditure> RecurringExpenditures { get; set; }
        public DbSet<RecurringIncome> RecurringIncomes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
