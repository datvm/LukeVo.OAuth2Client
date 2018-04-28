using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace LukeVo.OAuth2Client.Test
{
    internal static class Utils
    {

        public static NameValueCollection ParseQueryString(this Uri uri)
        {
            return System.Web.HttpUtility.ParseQueryString(uri.Query);
        }

    }
}
