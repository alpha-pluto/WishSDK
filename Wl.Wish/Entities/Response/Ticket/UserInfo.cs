/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：UserInfo.cs
    文件功能描述：用户信息实体 ( 与wish ticket 对应 )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class UserInfo
    {
        public string id { get; set; }

        public string joined_date { get; set; }

        public string locale { get; set; }

        public string name { get; set; }


    }
}
