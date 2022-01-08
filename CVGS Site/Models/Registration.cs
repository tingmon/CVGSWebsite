using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Registration
    {
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EventId { get; set; }

        public virtual EventLog Event { get; set; }
    }
}
