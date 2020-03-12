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

        //Navigation properties
        public List<UserProfile> UserProfiles { get; set; }
        public Subscription Subscripiton { get; set; }
    }
}
