using System;
using System.ComponentModel.DataAnnotations;

namespace Lims.ViewModels
{
    public class PurchaseDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        public int CustomerCount { get; set; }
    }
}