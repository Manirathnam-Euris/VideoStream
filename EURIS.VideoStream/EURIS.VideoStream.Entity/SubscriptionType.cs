using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class SubscriptionType
    {
        public Guid SubscriptionTypeId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public List<UserProfile> UserProfile { get; set; }
        public Subscription Subscripiton { get; set; }
    }
}
