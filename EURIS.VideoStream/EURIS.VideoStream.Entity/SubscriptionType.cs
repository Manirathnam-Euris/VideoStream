using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class SubscriptionType
    {
        [Key]
        //Scalar properties
        public Guid SubscriptionTypeId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid SubscriptionId { get; set; }

        //Navigation properties
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public Subscription Subscripiton { get; set; }
    }
}
