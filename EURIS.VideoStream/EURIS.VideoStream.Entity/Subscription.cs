using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class Subscription
    {
        [Key]
        //Scalar properties
        public Guid SubscriptionId { get; set; }
        public int Price { get; set; }
        //public string SubscriptionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public Guid UserId { get; set; }

        //Navigation properties
        //public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<SubscriptionType> SubscriptionTypes { get; set; }
    }
}
