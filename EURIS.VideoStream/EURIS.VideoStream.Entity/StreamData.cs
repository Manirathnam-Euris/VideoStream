﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Entity
{
    public class StreamData
    {
        //Scalar properties
        public Guid StreamDataId { get; set; }
        public DateTime StreamDate { get; set; }
        public DateTime StreamTime { get; set; }
        public int StreamLength { get; set; }
        public string StreamRate { get; set; }

        //Navigation properties
        public UserProfile UserProfile { get; set; }
        public MediaContent MediaContent { get; set; }
    }
}