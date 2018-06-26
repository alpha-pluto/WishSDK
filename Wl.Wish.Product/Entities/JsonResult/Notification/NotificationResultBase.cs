/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：NotificationResultBase.cs
    文件功能描述：Notification API 最简单 返回实体( 从 Wish 返回  )

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
    public class NotificationResultBase : WishJsonResult
    {
        public NotificationSampleData data { get; set; }
    }

    [Serializable]
    public class NotificationSampleData
    {
        public bool success { get; set; }

        public int count { get; set; }
    }

}
