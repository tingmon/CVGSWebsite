using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class GameStatus
    {
        public GameStatus()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}
