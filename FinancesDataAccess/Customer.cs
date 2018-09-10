namespace FinancesDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
