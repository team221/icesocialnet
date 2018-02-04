using System;
using System.Collections.Generic;
using System.Text;

namespace IceSocialNet.Model
{
    public class MessageBoard
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public Owner owner { get; set; }
    }
}
