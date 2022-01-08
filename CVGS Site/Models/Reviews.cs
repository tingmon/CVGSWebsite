using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public Guid GameId { get; set; }
        public int PersonId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string Review { get; set; }

        public virtual Game Game { get; set; }
        public virtual Person Person { get; set; }
    }
}
