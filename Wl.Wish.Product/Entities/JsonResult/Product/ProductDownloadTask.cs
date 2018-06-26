/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ProductDownloadTask.cs
    文件功能描述：商品下载任务的实体(与wish 对应)

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
    public class ProductDownloadTask : WishJsonResult
    {
        public Wl.Wish.Entities.Response.ProductDownloadTask data { get; set; }
    }
}
