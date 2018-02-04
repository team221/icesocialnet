using System;
using System.Collections.Generic;
using System.Text;

namespace IceSocialNet.Model
{
    public class LoginToken
    {
        public string auth_token { get; set; }
        public string api_key { get; set; }
        public string gcm_sender_id { get; set; }
        public string username { get; set; }
    }
}
