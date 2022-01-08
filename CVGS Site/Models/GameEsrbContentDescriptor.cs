using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class GameEsrbContentDescriptor
    {
        public Guid GameGuid { get; set; }
        public int EsrbContentDescriptorId { get; set; }
        public string UserName { get; set; }

        public virtual EsrbContentDescriptor EsrbContentDescriptor { get; set; }
        public virtual Game GameGu { get; set; }
    }
}
