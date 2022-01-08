using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class SupplierContact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string LandLine { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
