
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class ProductShippingPriceMultiple : WishJsonResult
    {
        public ProductShippingPriceMultipleDataContainer data { get; set; }
    }

    [Serializable]
    public class ProductShippingPriceMultipleDataContainer
    {

        public ProductShippingPriceMultipleWrapper ProductCountryAllShipping { get; set; }

    }

    [Serializable]
    public class ProductShippingPriceMultipleWrapper
    {
        public string id { get; set; }

        public List<ProductShippingPriceSingleWrapper> shipping_prices { get; set; }
    }
}
