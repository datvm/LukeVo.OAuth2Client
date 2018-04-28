using System;
using System.Collections.Generic;
using System.Text;

namespace LukeVo.OAuth2Client
{

    public class OAuth2ClientBuilder
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public Uri RedirectUri { get; set; }

    }

}
