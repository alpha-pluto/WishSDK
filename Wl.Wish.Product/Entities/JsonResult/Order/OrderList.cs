/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OrderList.cs
    文件功能描述：发货详情(Wish 返回 的订单实体中的发货详情部分)

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
    public class OrderList : WishJsonResult
    {
        public List<OrderWrapper> data { get; set; }

        public Wl.Wish.Entities.Paging paging { get; set; }
    }
}
