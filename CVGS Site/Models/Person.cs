using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Person
    {
        public Person()
        {
            Cart = new HashSet<Cart>();
            CreditCardRecord = new HashSet<CreditCardRecord>();
            EventLog = new HashSet<EventLog>();
            Reviews = new HashSet<Reviews>();
            SalesRecord = new HashSet<SalesRecord>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string LandLine { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<CreditCardRecord> CreditCardRecord { get; set; }
        public virtual ICollection<EventLog> EventLog { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<SalesRecord> SalesRecord { get; set; }
    }
}
