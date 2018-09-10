using RandomNameGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancesDataAccess.TestConsole
{
    public class Fake
    {
        public static List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Name = $"{NameGenerator.Generate(Gender.Female)}",
                    SSN = Guid.NewGuid().ToString("N"),
                    Accounts = Accounts()
                }
            };
        }

        public static List<Account> Accounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Transactions = Transactions()
                }
            };
        }

        public static List<Transaction> Transactions()
        {
            return new List<Transaction>
            {
                Transaction(1000, "Credit"),
                Transaction(300, "Debit")
            };
        }

        public static Transaction Transaction(double amount, string description)
        {
            return new Transaction
            {
                Amount = amount,
                Description = description,
                TransactionDate = DateTime.Now
            };
        }
    }
}
