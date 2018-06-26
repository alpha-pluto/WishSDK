/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：Announcement.cs
    文件功能描述：公告实体 (与Wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Announcement
    {
        public string title { get; set; }

        public string created { get; set; }

        public string bd_id { get; set; }

        public string bd_name { get; set; }

        public string message { get; set; }

        public bool viewed { get; set; }
    }
}
