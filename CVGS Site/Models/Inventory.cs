using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Inventory
    {
        public Guid ProductGuid { get; set; }
        public string LocationGln { get; set; }
        public short NewOnHand { get; set; }
        public short NewOnOrder { get; set; }
        public short UsedOnHand { get; set; }
        public string UserName { get; set; }

        public virtual Location LocationGlnNavigation { get; set; }
        public virtual Product ProductGu { get; set; }
    }
}
