/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：OrderDownloadTask.cs
    文件功能描述：订单下载任务的实体(与wish 对应)

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
    public class OrderDownloadTask : WishJsonResult
    {
        public Wl.Wish.Entities.Response.OrderDownloadTask data { get; set; }
    }
}
