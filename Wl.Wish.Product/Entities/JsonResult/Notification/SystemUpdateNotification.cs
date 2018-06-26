/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：SystemUpdatesNotification.cs
    文件功能描述：系统更新回复消息 实体( 从 Wish 返回  )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;
using Wl.Wish.Entities.Response;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class SystemUpdateNotification : WishJsonResult
    {
        public List<SystemUpdatesResponseWrapper> data { get; set; }
    }

}
