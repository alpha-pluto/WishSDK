/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：CountryShippingSetting.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关商品的操作)

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
    public class CountryShippingSetting
    {
        /// <summary>
        ///  The 2 letter country code of the shipping price.
        /// </summary>
        public string country_code { get; set; }

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
    }
}
