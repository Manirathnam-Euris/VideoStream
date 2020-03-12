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
        public UserAccount UserAccounts { get; set; }
        public List<StreamData> StreamDatas { get; set; }
        public List<SavedMedia> SavedMedias{ get; set; }
        public List<Favourites> Favourites { get; set; }
    }
}
