namespace FinancesDataAccess.TestConsole
{
    using Microsoft.EntityFrameworkCore;
    using RandomNameGenerator;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FinancesContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            RegisterCustomers().Wait();
            ListCustomers().Wait();
        }

        static async Task RegisterCustomers()
        {
            using (var context = new FinancesContext())
            {
                var customers = GetCustomers();

                foreach (var customer in customers)
                {
                    await context.Customers.AddAsync(customer);
                }

                await context.SaveChangesAsync();
            }
        }

        static async Task ListCustomers()
        {
            using (var context = new FinancesContext())
            {
                var customers = await context.Customers
                    .Include(customer => customer.Accounts)
                        .ThenInclude(account => account.Transactions)
                    .ToListAsync();

                foreach (var customer in customers)
                {
                    DisplayCustomerData(customer);
                }
                Console.ReadKey();
            }
        }

        static void DisplayCustomerData(Customer customer)
        {
            Console.WriteLine($"{customer.CustomerId} - {customer.Name} - {customer.SSN}");
            foreach (var account in customer.Accounts)
            {
                Console.WriteLine($"{account.AccountId}");
                foreach (var transaction in account.Transactions)
                {
                    Console.WriteLine($"{transaction.TransactionId} - {transaction.Description} - {transaction.Amount} - {transaction.TransactionDate}");
                }
            }
            Console.WriteLine();
        }

        static List<Customer> GetCustomers()
        {
            return Fake.Customers();
        }
    }
}
