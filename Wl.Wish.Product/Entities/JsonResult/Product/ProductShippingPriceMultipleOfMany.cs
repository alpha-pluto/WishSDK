/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ProductShippingPriceMultipleOfMany.cs
    文件功能描述：多个商品的多个运费实体

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    /// <summary>
    /// 多个商品的多个运费实体 JSON
    /// </summary>
    [Serializable]
    public class ProductShippingPriceMultipleOfMany : WishJsonResult
    {
        public List<ProductShippingPriceMultipleDataContainer> data { get; set; }
    }
}
