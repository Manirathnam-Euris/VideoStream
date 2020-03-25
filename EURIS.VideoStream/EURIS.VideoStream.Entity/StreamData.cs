using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class StreamData
    {
        //Scalar properties
        [Key]
        public Guid StreamDataId { get; set; }
        public DateTime StreamDate { get; set; }
        public DateTime StreamTime { get; set; }
        public int StreamLength { get; set; }
        public string StreamRate { get; set; }
        public Guid UserProfileId { get; set; }
        public Guid ContentId { get; set; }

        //Navigation properties
        public UserProfile UserProfile { get; set; }
        public MediaContent MediaContent { get; set; }
    }
}
