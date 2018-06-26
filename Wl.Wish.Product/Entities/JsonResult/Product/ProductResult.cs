/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ProductResult.cs
    文件功能描述：商品回馈数据

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
    public class ProductResult : WishJsonResult
    {
        public ProductWrapper data { get; set; }
    }

    [Serializable]
    public class ProductWrapper
    {
        public Wl.Wish.Entities.Response.Product Product { get; set; }
    }

}
