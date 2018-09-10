namespace FinancesDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Transaction
    {
        public Guid TransactionId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
