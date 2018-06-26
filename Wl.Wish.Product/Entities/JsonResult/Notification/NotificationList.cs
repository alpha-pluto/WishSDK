/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：NotificationList.cs
    文件功能描述：Notification 列表  实体( 从 Wish 返回  )

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
    public class NotificationList : WishJsonResult
    {
        public List<NotificationEntityWrapper> data { get; set; }

        public Wl.Wish.Entities.Paging paging { get; set; }
    }

    [Serializable]
    public class NotificationEntityWrapper
    {
        public Wl.Wish.Entities.Response.NotificationEntity GetNotiResponse { get; set; }
    }

}
