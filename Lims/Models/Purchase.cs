using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lims.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }

        [DisplayFormat(NullDisplayText = "Out of stock")]
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }

    }
}