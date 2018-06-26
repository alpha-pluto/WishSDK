using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class VariantWrapper
    {
        public VariantEntity Variant { get; set; }
    }

    [Serializable]
    public class VariantEntity
    {
        /// <summary>
        /// The Wish Id of the product variation, a string of 24 characters
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///  The Wish Id of the product this product variation belongs to, a 24 character string
        /// </summary>
        public string product_id { get; set; }

        /// <summary>
        /// The unique identifier that your system uses to recognize this variation
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        ///  The color of the variation
        /// </summary>
        public string color { get; set; }

        /// <summary>
        ///  The size of the variation
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// The physical quantities you have for this variation, max 500,000
        /// </summary>
        public int inventory { get; set; }

        /// <summary>
        ///  The price of the variation when the user purchases one
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        ///  The shipping of the variation when the user purchases one
        /// </summary>
        public decimal shipping { get; set; }

        /// <summary>
        /// The manufacturer suggested retail price of the variation
        /// </summary>
        public decimal msrp { get; set; }

        /// <summary>
        ///  Whether or not this product variation is enabled for purchase
        /// </summary>
        public bool enabled { get; set; }

        /// <summary>
        ///  The amount of time it takes for the shipment to reach the buyer
        /// </summary>
        public string shipping_time { get; set; }

        /// <summary>
        ///  Url of all images of the product this product variation belongs to, separated by the character '|'
        /// </summary>
        public string all_images { get; set; }

    }
}
