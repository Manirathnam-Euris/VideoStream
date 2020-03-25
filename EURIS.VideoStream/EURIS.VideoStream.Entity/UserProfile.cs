using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class UserProfile
    {
        //Scalar properties
        [Key]
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public Guid UserId { get; set; }
        public Guid SubscriptionTypeId { get; set; }

        //Navigation properties
        public UserAccount UserAccount { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public virtual ICollection<StreamData> StreamDatas { get; set; }
        public virtual ICollection<SavedMedia> SavedMedias { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
    }
}
