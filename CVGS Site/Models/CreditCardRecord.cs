using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class CreditCardRecord
    {
        public int CardId { get; set; }
        public int PersonId { get; set; }
        public string CardCode { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }

        public virtual CreditCard CardCodeNavigation { get; set; }
        public virtual Person Person { get; set; }
    }
}
