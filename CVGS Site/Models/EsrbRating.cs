using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class EsrbRating
    {
        public EsrbRating()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishRating { get; set; }
        public string FrenchRating { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}
