using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class GameCompany
    {
        public GameCompany()
        {
            ProductDeveloper = new HashSet<Product>();
            ProductPublisher = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Product> ProductDeveloper { get; set; }
        public virtual ICollection<Product> ProductPublisher { get; set; }
    }
}
