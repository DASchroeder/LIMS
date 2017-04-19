using System;
using System.Collections.Generic;
using System.Text;

namespace Lims.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}
