using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Province
    {
        public Province()
        {
            Location = new HashSet<Location>();
            Person = new HashSet<Person>();
            Population = new HashSet<Population>();
            Supplier = new HashSet<Supplier>();
        }

        public string Code { get; set; }
        public string CountryCode { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
        public double? FederalTax { get; set; }
        public string FederalTaxAcronym { get; set; }
        public double? ProvincialTax { get; set; }
        public string ProvincialTaxAcronym { get; set; }
        public bool? PstOnGst { get; set; }

        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Population> Population { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
