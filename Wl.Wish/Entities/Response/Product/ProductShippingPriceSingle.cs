/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ProductShippingPriceSingle.cs
    文件功能描述：Wish返回 的 商品运费实体(与wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Helpers;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class ProductShippingPriceSingle
    {
        /// <summary>
        ///  The 2 letter country code of the shipping price.
        /// </summary>
        public string country_code { get; set; }

        /// <summary>
        ///  Product ID of the product in question.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 	'True'/'False'. If 'True' then the product shipping price to the country is determined by the product variations.If 'False' then the product shipping price is the fixed value in the field shipping_price.
        /// </summary>
        public bool? use_product_shipping { get; set; }

        /// <summary>
        ///  The shipping price of the product to the country.This field could be a number to indicate a shipping price.
        ///  It could also be the string "Use Product Shipping Price" to indicate that the shipping price to this country is determined by the product variations.
        ///  原来是decimal 类型，但是有些返回并不是decimal 
        /// </summary>
        public string shipping_price { get; set; }

        [JsonSetting.IgnoreValue(true)]
        [Newtonsoft.Json.JsonIgnore]
        public decimal? ShippingPrice
        {
            get
            {
                decimal ret = 0;
                if (decimal.TryParse(shipping_price, out ret))
                {
                    return ret;
                }
                return null;

            }
        }

        /// <summary>
        ///  'True' / 'False'.If 'True' then the product is available for sale in this country.If 'False' then the product is not available for sale in this country.
        /// </summary>
        public bool? enabled { get; set; }

        /// <summary>
        /// 'True'/'False'. If 'True' then the product is part of the Wish Express program and must be shipped to customers in that country within 5 working days.
        /// </summary>
        public bool? wish_express { get; set; }
    }
}
