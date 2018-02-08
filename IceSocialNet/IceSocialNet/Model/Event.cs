using System;
using System.Collections.Generic;
using System.Text;

namespace IceSocialNet.Model
{
    public class Event
    {
        public int Guid { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public Double Lat { get; set; }

        public string Time_Create { get; set; }

        public Double Lng { get; set; }

        public string Title { get; set; }

        public Owner Owner { get; set; } 
    }
}
