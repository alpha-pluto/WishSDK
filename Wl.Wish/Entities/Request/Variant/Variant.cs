/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Variant.cs
    文件功能描述：商品规格实体(与wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Request
{
    [Serializable]
    public class Variant
    {
        /// <summary>
        /// The parent_sku of the product this new product variation should be added to. If the product is missing a parent_sku, then this should be the SKU of a product variation of the product
        /// </summary>
        public string parent_sku { get; set; }

        /// <summary>
        ///  The unique identifier for the variation you would like to update
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// optional The physical quantities you have for this variation, max 500,000
        /// </summary>
        public int inventory { get; set; }

        /// <summary>
        /// optional The price of the variation when the user purchases one, max 100,000
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        ///  optional The shipping of the variation when the user purchases one, max 1000
        /// </summary>
        public decimal shipping { get; set; }

        /// <summary>
        /// optional True if the variation is for sale, False if you need to halt sales.
        /// </summary>
        /// public bool? enabled { get; set; }

        /// <summary>
        ///  optional The size of the variation.Example: Large, Medium, Small, 5, 6, 7.5
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// optional The color of the variation.Example: red, blue, green
        /// </summary>
        public string color { get; set; }

        /// <summary>
        ///  optional Manufacturer's Suggested Retail Price.
        /// </summary>
        public decimal? msrp { get; set; }

        /// <summary>
        /// optional The amount of time it takes for the shipment to reach the buyer.Please also factor in the time it will take to fulfill and ship the item.Provide a time range in number of days.Lower bound cannot be less than 2 days.Upper bound must be at least 5 days after the lower bound.Example: 5-10
        /// </summary>
        public string shipping_time { get; set; }

        /// <summary>
        /// optional URL of a photo for this variant. Provide this when you have different pictures for different variant of the product. If left out, it'll use the main_image of the product with the provided parent_sku. Link directly to the image, not the page where it is located. We accept JPEG, PNG or GIF format. Images should be at least 100 x 100 pixels in size.
        /// </summary>
        public string main_image { get; set; }

    }
}
