namespace FinancesDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Account
    {
        public Guid AccountId { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
