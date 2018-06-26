/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：AccessTokenResult.cs
    文件功能描述：开放平台AccessToken实体

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class AccessTokenResult : WishJsonResult
    {
        public AccessTokenResult()
        {
            data = new AccessTokenData();
        }
        public AccessTokenData data { get; set; }
    }

    [Serializable]
    public class AccessTokenData
    {
        public string access_token { get; set; }

        public string refresh_token { get; set; }

        public int expires_in { get; set; }

        public int expiry_time { get; set; }
    }
}
