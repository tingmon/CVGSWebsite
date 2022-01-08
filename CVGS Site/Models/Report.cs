using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportBody { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
