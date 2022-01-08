using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class EventRegister
    {
        public int RegisterEventId { get; set; }
        public int EventId { get; set; }
        public int RegistrationId { get; set; }

        public virtual EventLog Event { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
