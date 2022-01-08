using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CVGS_Site.Models
{
    public partial class Game
    {
        public Game()
        {
            GameEsrbContentDescriptor = new HashSet<GameEsrbContentDescriptor>();
            Product = new HashSet<Product>();
            Reviews = new HashSet<Reviews>();
        }

        public Guid Guid { get; set; }
        public string GameStatusCode { get; set; }
        public int GameCategoryId { get; set; }
        public int? GameSubCategoryId { get; set; }
        public string EsrbRatingCode { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
        public bool FrenchVersion { get; set; }
        public string EnglishPlayerCount { get; set; }
        public string FrenchPlayerCount { get; set; }
        public string GamePerspectiveCode { get; set; }
        public string EnglishTrailer { get; set; }
        public string FrenchTrailer { get; set; }
        public string EnglishDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string EnglishDetail { get; set; }
        public string FrenchDetail { get; set; }
        public string UserName { get; set; }
        public int? Rating { get; set; }
        public int? RatingCount { get; set; }
        public int? RatingTotal { get; set; }
        public double? Price { get; set; }

        public virtual EsrbRating EsrbRatingCodeNavigation { get; set; }
        public virtual GameCategory GameCategory { get; set; }
        public virtual GamePerspective GamePerspectiveCodeNavigation { get; set; }
        public virtual GameStatus GameStatusCodeNavigation { get; set; }
        public virtual GameSubCategory GameSubCategory { get; set; }
        public virtual ICollection<GameEsrbContentDescriptor> GameEsrbContentDescriptor { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
