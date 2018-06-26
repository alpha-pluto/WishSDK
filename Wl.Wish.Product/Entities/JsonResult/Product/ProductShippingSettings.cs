using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class ProductShippingSettings : WishJsonResult
    {
        public ProductShippingSettingsContainer data { get; set; }
    }

    [Serializable]
    public class ProductShippingSettingsContainer
    {
        public ProductShippingSettingsWrapper ShippingSetting { get; set; }
    }

    [Serializable]
    public class ProductShippingSettingsWrapper
    {
        public bool ships_worldwide { get; set; }

        public List<ProductShippingSettingSingleWrapper> country_settings { get; set; }

    }

    [Serializable]
    public class ProductShippingSettingSingleWrapper
    {
        public Wl.Wish.Entities.Response.CountryShippingSetting CountryShippingSetting { get; set; }
    }
}
