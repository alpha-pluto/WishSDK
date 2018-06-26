/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OrderResult.cs
    文件功能描述：订单详情(Wish 返回 的订单实体)

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
    public class OrderResult : WishJsonResult
    {
        public OrderWrapper data { get; set; }
    }

    [Serializable]
    public class OrderWrapper
    {
        public Wl.Wish.Entities.Response.Order Order { get; set; }
    }
}
