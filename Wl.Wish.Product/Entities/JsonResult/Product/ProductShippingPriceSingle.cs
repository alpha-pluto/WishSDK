using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class ProductShippingPriceSingle : WishJsonResult
    {
        public ProductShippingPriceSingleWrapper data { get; set; }
    }

    [Serializable]
    public class ProductShippingPriceSingleWrapper
    {
        public Wl.Wish.Entities.Response.ProductShippingPriceSingle ProductCountryShipping { get; set; }
    }
}
