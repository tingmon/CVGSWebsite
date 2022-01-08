using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class SalesRecord
    {
        public Guid RecordId { get; set; }
        public int PersonId { get; set; }
        public string ProductList { get; set; }
        public string CreditCard { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Amount { get; set; }

        public virtual Person Person { get; set; }
    }
}
