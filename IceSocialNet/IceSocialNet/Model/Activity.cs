using System;
using System.Collections.Generic;
using System.Text;

namespace IceSocialNet.Model
{
    public class Activity
    {
        public Int64 guid { get; set; }

        public string Description { get; set; }

        public string Time_Created { get; set; }

        public string Like_Count { get; set; }

        public string Like { get; set; }

        public string Comment_Count { get; set; }

        public Owner Owner { get; set; }
    }
}
