/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ProductShippingPriceMultiple.cs
    文件功能描述：修改商品多国运费的实体(与wish 对应)

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Request
{
    [Serializable]
    public class ProductShippingPriceMultiple
    {
        /// <summary>
        /// Required The unique Wish identifier for this product
        /// </summary>
        public string id { get; set; }

        #region shipping to various regions


        /// <summary>
        /// United Arab Emirates
        /// </summary>
        public decimal? AE { get; set; }

        /// <summary>
        /// Argentina
        /// </summary>
        public decimal? AR { get; set; }

        /// <summary>
        /// Austria
        /// </summary>
        public decimal? AT { get; set; }

        /// <summary>
        /// Australia
        /// </summary>
        public decimal? AU { get; set; }

        /// <summary>
        /// Belgium
        /// </summary>
        public decimal? BE { get; set; }

        /// <summary>
        /// Bulgaria
        /// </summary>
        public decimal? BG { get; set; }

        /// <summary>
        /// Brazil
        /// </summary>
        public decimal? BR { get; set; }

        /// <summary>
        /// Belarus
        /// </summary>
        public decimal? BY { get; set; }

        /// <summary>
        /// Canada
        /// </summary>
        public decimal? CA { get; set; }

        /// <summary>
        /// Switzerland
        /// </summary>
        public decimal? CH { get; set; }

        /// <summary>
        /// Chile
        /// </summary>
        public decimal? CL { get; set; }

        /// <summary>
        /// Colombia
        /// </summary>
        public decimal? CO { get; set; }

        /// <summary>
        /// Costa Rica
        /// </summary>
        public decimal? CR { get; set; }

        /// <summary>
        /// Czech Republic
        /// </summary>
        public decimal? CZ { get; set; }

        /// <summary>
        /// Germany
        /// </summary>
        public decimal? DE { get; set; }

        /// <summary>
        /// Denmark
        /// </summary>
        public decimal? DK { get; set; }

        /// <summary>
        /// Ecuador
        /// </summary>
        public decimal? EC { get; set; }

        /// <summary>
        /// Estonia
        /// </summary>
        public decimal? EE { get; set; }

        /// <summary>
        /// Egypt
        /// </summary>
        public decimal? EG { get; set; }

        /// <summary>
        /// Spain
        /// </summary>
        public decimal? ES { get; set; }

        /// <summary>
        /// Finland
        /// </summary>
        public decimal? FI { get; set; }

        /// <summary>
        /// France
        /// </summary>
        public decimal? FR { get; set; }

        /// <summary>
        /// United Kingdom (Great Britain)
        /// </summary>
        public decimal? GB { get; set; }

        /// <summary>
        /// Greece
        /// </summary>
        public decimal? GR { get; set; }

        /// <summary>
        /// Hong Kong
        /// </summary>
        public decimal? HK { get; set; }

        /// <summary>
        /// Croatia
        /// </summary>
        public decimal? HR { get; set; }

        /// <summary>
        /// Hungary
        /// </summary>
        public decimal? HU { get; set; }

        /// <summary>
        /// Indonesia
        /// </summary>
        public decimal? ID { get; set; }

        /// <summary>
        /// Ireland
        /// </summary>
        public decimal? IE { get; set; }

        /// <summary>
        /// Israel
        /// </summary>
        public decimal? IL { get; set; }

        /// <summary>
        /// India
        /// </summary>
        public decimal? IN { get; set; }

        /// <summary>
        /// Italy
        /// </summary>
        public decimal? IT { get; set; }

        /// <summary>
        /// Jamaica
        /// </summary>
        public decimal? JM { get; set; }

        /// <summary>
        /// Jordan
        /// </summary>
        public decimal? JO { get; set; }

        /// <summary>
        /// Japan
        /// </summary>
        public decimal? JP { get; set; }

        /// <summary>
        /// South Korea
        /// </summary>
        public decimal? KR { get; set; }

        /// <summary>
        /// Kuwait
        /// </summary>
        public decimal? KW { get; set; }

        /// <summary>
        /// Liechtenstein
        /// </summary>
        public decimal? LI { get; set; }

        /// <summary>
        /// Lithuania
        /// </summary>
        public decimal? LT { get; set; }

        /// <summary>
        /// Luxembourg
        /// </summary>
        public decimal? LU { get; set; }

        /// <summary>
        /// Latvia
        /// </summary>
        public decimal? LV { get; set; }

        /// <summary>
        /// Morocco
        /// </summary>
        public decimal? MA { get; set; }

        /// <summary>
        /// Monaco
        /// </summary>
        public decimal? MC { get; set; }

        /// <summary>
        /// Mexico
        /// </summary>
        public decimal? MX { get; set; }

        /// <summary>
        /// Malaysia
        /// </summary>
        public decimal? MY { get; set; }

        /// <summary>
        /// Netherlands
        /// </summary>
        public decimal? NL { get; set; }

        /// <summary>
        /// Norway
        /// </summary>
        public decimal? NO { get; set; }

        /// <summary>
        /// New Zealand
        /// </summary>
        public decimal? NZ { get; set; }

        /// <summary>
        /// Peru
        /// </summary>
        public decimal? PE { get; set; }

        /// <summary>
        /// Philippines
        /// </summary>
        public decimal? PH { get; set; }

        /// <summary>
        /// Pakistan
        /// </summary>
        public decimal? PK { get; set; }

        /// <summary>
        /// Poland
        /// </summary>
        public decimal? PL { get; set; }

        /// <summary>
        /// Puerto Rico
        /// </summary>
        public decimal? PR { get; set; }

        /// <summary>
        /// Portugal
        /// </summary>
        public decimal? PT { get; set; }

        /// <summary>
        /// Romania
        /// </summary>
        public decimal? RO { get; set; }

        /// <summary>
        /// Russia
        /// </summary>
        public decimal? RU { get; set; }

        /// <summary>
        /// Saudi Arabia
        /// </summary>
        public decimal? SA { get; set; }

        /// <summary>
        /// Sweden
        /// </summary>
        public decimal? SE { get; set; }

        /// <summary>
        /// Singapore
        /// </summary>
        public decimal? SG { get; set; }

        /// <summary>
        /// Slovenia
        /// </summary>
        public decimal? SI { get; set; }

        /// <summary>
        /// Slovakia
        /// </summary>
        public decimal? SK { get; set; }

        /// <summary>
        /// Thailand
        /// </summary>
        public decimal? TH { get; set; }

        /// <summary>
        /// Turkey
        /// </summary>
        public decimal? TR { get; set; }

        /// <summary>
        /// Taiwan
        /// </summary>
        public decimal? TW { get; set; }

        /// <summary>
        /// Ukraine
        /// </summary>
        public decimal? UA { get; set; }

        /// <summary>
        /// United States
        /// </summary>
        public decimal? US { get; set; }

        /// <summary>
        /// Venezuela
        /// </summary>
        public decimal? VE { get; set; }

        /// <summary>
        /// Virgin Islands, British
        /// </summary>
        public decimal? VG { get; set; }

        /// <summary>
        /// Virgin Islands, U.S.
        /// </summary>
        public decimal? VI { get; set; }

        /// <summary>
        /// Vietnam
        /// </summary>
        public decimal? VN { get; set; }

        /// <summary>
        /// South Africa
        /// </summary>
        public decimal? ZA { get; set; }


        #endregion

        /// <summary>
        /// A string that consists of country codes separated by comma. For example, 'AU,CA,US'. Each country will use the product variation shipping price.
        /// </summary>
        public string use_product_shipping_countries { get; set; }

        /// <summary>
        /// A string that consists of country codes separated by comma. For example, 'AU,CA,US'. Users in disabled countries cannot see or buy the product.
        /// </summary>
        public string disabled_countries { get; set; }

        /// <summary>
        /// A string that consists of country codes separated by comma. For example, 'AU,CA,US'. 
        /// The product must be shipped to a customer in any of those countries within 5 working days. 
        /// Warning: Wish Express countries cannot be disabled for promoted products. If you make a mistake, you must correct it immediately.
        /// </summary>
        public string wish_express_add_countries { get; set; }

        /// <summary>
        /// A string that consists of country codes separated by comma. For example, 'AU,CA,US'.
        /// </summary>
        public string wish_express_remove_countries { get; set; }

    }
}
