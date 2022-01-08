using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class EventLog
    {
        public EventLog()
        {
            Registration = new HashSet<Registration>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Detail { get; set; }
        public string Creator { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
