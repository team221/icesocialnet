using System;
using System.Collections.Generic;
using System.Text;

namespace IceSocialNet.Model
{
    public class Group
    {
        public int Guid { get; set; }

        public string Title { get; set; }

        public string Time_Create { get; set; }

        public string Description { get; set; }

        public int Access_Id { get; set; }

        public int Members { get; set; }

        public bool Is_Member { get; set; }

        public bool Permission_Public { get; set; }

        public string Content_Access_Mode { get; set; }

        public string Icon { get; set; }

        public string[] Tags { get; set; }

        public Owner Owner { get; set; }
    }
}
