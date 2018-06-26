/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Product.cs
    文件功能描述：商品实体(与wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Request
{
    [Serializable]
    public class Product
    {
        /// <summary>
        /// Name of the product as shown to users on Wish
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of the product.Should not contain HTML.If you want a new line use "\n".
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Comma separated list of strings that describe the product.Only 10 are allowed. Any tags past 10 will be ignored.
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// The unique identifier that your system uses to recognize this product
        /// </summary>
        public string sku { get; set; }

        /// <summary>
        /// optional The color of the product.Example: red, blue, green
        /// </summary>
        public string color { get; set; }

        /// <summary>
        /// optional The size of the product.Example: Large, Medium, Small, 5, 6, 7.5
        /// </summary>
        public string size { get; set; }

        /// <summary>
        /// The physical quantities you have for this product, max 500,000
        /// </summary>
        public int inventory { get; set; }

        /// <summary>
        /// The price of the product when the user purchases one, max 100,000
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// The shipping of the product when the user purchases one, max 1000
        /// </summary>
        public decimal shipping { get; set; }

        /// <summary>
        /// optional Manufacturer's Suggested Retail Price. This field is recommended as it will show as a strikethrough price on Wish and appears above the selling price for the product.
        /// </summary>
        public decimal? msrp { get; set; }

        /// <summary>
        /// optional The amount of time it takes for the shipment to reach the buyer.Please also factor in the time it will take to fulfill and ship the item.Provide a time range in number of days.Lower bound cannot be less than 2 days.Upper bound must be at least 5 days after the lower bound.Example: 15-20
        /// </summary>
        public string shipping_time { get; set; }

        /// <summary>
        /// URL of a photo of your product.Link directly to the image, not the page where it is located.We accept JPEG, PNG or GIF format. Images should be at least 100 x 100 pixels in size.
        /// </summary>
        public string main_image { get; set; }

        /// <summary>
        /// optional When defining a variant of a product we must know which product to attach the variation to.parent_sku is the unique id of the product that you can use later when using the add product variation API.
        /// </summary>
        public string parent_sku { get; set; }

        /// <summary>
        /// optional Brand or manufacturer of your product
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        /// optional URL on your website containing the product details
        /// </summary>
        public string landing_page_url { get; set; }

        /// <summary>
        /// optional 12-digit Universal Product Codes(UPC)-contains no letters or other characters
        /// </summary>
        public string upc { get; set; }

        /// <summary>
        /// optional URL of extra photos of your product. Link directly to the image, not the page where it is located. Same rules apply as main_image. You can specify one or more additional images separated by the character '|'. The total number of extra images plus the number of variation images must not exceed 20.
        /// </summary>
        public string extra_images { get; set; }
    }

    [Serializable]
    public class ProductToUpdate
    {
        /// <summary>
        /// Must provide either id or parent_sku Wish's unique identifier for the product you would like to update
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///  Must provide either id or parent_sku The parent sku for the product you would like to update
        /// </summary>
        public string parent_sku { get; set; }

        /// <summary>
        /// optional Name of the product as shown to users
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// optional Description of the product.If you want a new line use "\n".
        /// </summary>
        public string description { get; set; }

        /// <summary>
        ///  optional Comma separated list of strings.The tags passed into this parameter will completely replace the tags that are currently on the product
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// optional Brand or manufacturer of your product
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        ///  optional URL on your website containing the product detail and buy button for the applicable product.
        /// </summary>
        public string landing_page_url { get; set; }

        /// <summary>
        ///  optional 12-digit Universal Product Codes(UPC)-contains no letters or other characters
        /// </summary>
        public string upc { get; set; }

        /// <summary>
        /// optional URL of a photo of your product.Link directly to the image, not the page where it is located.We accept JPEG, PNG or GIF format.Images should be at least 100 x 100 pixels in size.
        /// </summary>
        public string main_image { get; set; }

        /// <summary>
        ///  optional URL of a photo of your product.Link directly to the image, no
        /// </summary>
        public string extra_images { get; set; }

    }

}
