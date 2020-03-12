using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class UserAccount
    {
        //Scalar properties
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string CreditCardNumber { get; set; }

        //Navigation properties
        public List<UserProfile> UserProfiles { get; set; }
        public Subscription Subscription { get; set; }
    }
}
