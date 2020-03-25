using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class Favourites
    {
        //Scalar properties
        [Key]
        public Guid FavouritesId { get; set; }
        public string Name { get; set; }
        public Guid UserProfileId { get; set; }
        public Guid ContentId { get; set; }

        //Navigation properties
        public virtual UserProfile UserProfile { get; set; }
        //public virtual MediaContent MediaContent { get; set; }
    }
}
