/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OAuthAccessTokenResult.cs
    文件功能描述：开放平台AccessToken实体

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Open.OAuthAPIs
{
    [Serializable]
    public class OAuthAccessTokenResult : WishJsonResult
    {
        public OAuthAccessTokenData data { get; set; }
    }

    [Serializable]
    public class OAuthAccessTokenData
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public int expires_in { get; set; }

        public int expiry_time { get; set; }
    }

    [Serializable]
    public class OAuthAccessTokenTestResult : WishJsonResult
    {
        public OAuthAccessTokenTestData data { get; set; }
    }

    public class OAuthAccessTokenTestData
    {
        public string merchant_username { get; set; }
        public string merchant_id { get; set; }

        public bool success { get; set; }
    }

}
