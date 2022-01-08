using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class PopulationClassification
    {
        public PopulationClassification()
        {
            Population = new HashSet<Population>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Population> Population { get; set; }
    }
}
