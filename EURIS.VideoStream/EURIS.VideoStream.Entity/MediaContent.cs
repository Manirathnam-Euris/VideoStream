using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class MediaContent
    {
        //Scalar properties
        [Key]
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public int Episode { get; set; }
        public string Genre { get; set; }
        public int TimeLength { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Distributor { get; set; }
        public string Language { get; set; }
        public int AverageRating { get; set; }
        public string HeroName { get; set; }
        public string HeroineName { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ProductionHouse { get; set; }
        //public Guid SavedMediaId { get; set; }
        //public Guid FavouritesId { get; set; }

        //Navigation Properties
        //public virtual SavedMedia SavedMedia { get; set; }
        //public virtual Favourites Favourites { get; set; }
        public virtual ICollection<StreamData> StreamDatas { get; set; }
    }
}
