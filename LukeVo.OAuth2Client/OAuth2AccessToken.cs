﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LukeVo.OAuth2Client
{

    public class OAuth2AccessToken
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

    }

}
