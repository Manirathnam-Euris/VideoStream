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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation properties
        [Required]
        public UserAccount UserAccount { get; set; }
        public List<MediaContent> MediaContents { get; set; }
        public List<SubscriptionType> SubscriptionType { get; set; }
    }
}
