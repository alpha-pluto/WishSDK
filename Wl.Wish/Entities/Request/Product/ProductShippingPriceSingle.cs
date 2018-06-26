/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ProductShippingPriceSingle.cs
    文件功能描述：单个修改商品运费的实体(与wish 对应)

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Request
{
    [Serializable]
    public class ProductShippingPriceSingle
    {

        /// <summary>
        /// Must provide either id or parent_sku The unique Wish identifier for this product
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///  Must provide either id or parent_sku The parent sku for this product
        /// </summary>
        public string parent_sku { get; set; }

        /// <summary>
        /// Required The 2 letter country code.See Shippable Countries for a list of supported countries.Choose one from: AE, AR, AT, AU, BE, BG, BR, BY, CA, CH, CL, CO, 
        /// CR, CZ, DE, DK, EC, EE, EG, ES, FI, FR, GB, GR, HK, HR, HU, ID, IE, IL, IN, IT, JM, JO, JP, KR, KW, LI, LT, LU, LV, MA, MC, MX, MY, NL, NO, NZ, PE, PH, PK, 
        /// PL, PR, PT, RO, RU, SA, SE, SG, SI, SK, TH, TR, TW, UA, US, VE, VG, VI, VN, ZA,
        /// </summary>
        public string country { get; set; }

        /// <summary>
        ///  Required The shipping price(in USD) of this product to this country, max 1000.
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        ///  If this field is set to 'true', this product will use the product variation shipping prices for this country.
        /// </summary>
        public string use_product_shipping { get; set; }

        /// <summary>
        /// Determines if the product is enabled or disabled.Users from a disabled country will not be able to buy the product.
        /// </summary>
        public string enabled { get; set; }

        /// <summary>
        /// Determines whether the product is enrolled in the Wish Express program for this country. If yes, the product must be delivered to customers in that country within 5 working days.
        /// </summary>
        public string wish_express { get; set; }
    }
}
