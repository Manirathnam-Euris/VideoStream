using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class UserProfile
    {
        //Scalar properties
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }

        //Navigation properties
        public UserAccount UserAccount { get; set; }
        public List<StreamData> StreamData { get; set; }
        public List<SavedMedia> SavedMedia { get; set; }
        public List<Favourites> Favourites { get; set; }
    }
}
