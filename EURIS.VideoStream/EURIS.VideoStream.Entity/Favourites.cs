using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class Favourites
    {
        //Scalar properties
        public Guid FavouritesId { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public UserProfile UserProfile { get; set; }
        public List<MediaContent> MediaContent { get; set; }
    }
}
