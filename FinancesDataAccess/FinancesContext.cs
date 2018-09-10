namespace FinancesDataAccess
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FinancesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FinancesDB;Trusted_Connection=True;");
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
