using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class EsrbContentDescriptor
    {
        public EsrbContentDescriptor()
        {
            GameEsrbContentDescriptor = new HashSet<GameEsrbContentDescriptor>();
        }

        public int Id { get; set; }
        public string EnglishDescriptor { get; set; }
        public string FrenchDescriptor { get; set; }

        public virtual ICollection<GameEsrbContentDescriptor> GameEsrbContentDescriptor { get; set; }
    }
}
