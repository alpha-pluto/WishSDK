/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Product.cs
    文件功能描述：Wish返回 的 商品实体(与wish 对应)

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Product
    {
        /// <summary>
        /// The Wish Id of the product, a 24 character string
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// The name which you have given the product, example: 'Blue Shoe'
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Your unique identifier for the product
        /// </summary>
        public string parent_sku { get; set; }

        /// <summary>
        /// Number of sales this product has received
        /// </summary>
        public int number_sold { get; set; }

        /// <summary>
        ///  Number of times this product has been added to users' wishlists
        /// </summary>
        public int number_saves { get; set; }

        /// <summary>
        /// Our review status of the product, example: 'approved'
        /// </summary>
        public string review_status { get; set; }

        ///Comma separated list of tags which are applied to the product
        public List<TagWrapper> tags { get; set; }

        ///A blurb of text uploaded as the description to the product
        public string description { get; set; }

        //variants A list of Product Variation entities
        public List<VariantWrapper> variants { get; set; }

        /// <summary>
        ///  Brand or manufacturer of your product
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        ///  URL on your website containing the product details
        /// </summary>
        public string landing_page_url { get; set; }

        /// <summary>
        ///  12-digit Universal Product Codes(UPC)-contains no letters or other characters
        /// </summary>
        public string upc { get; set; }

        /// <summary>
        ///  URL of the main image of the product
        /// </summary>
        public string main_image { get; set; }

        /// <summary>
        ///  URL of all extra images of the product, separated by the character '|'
        /// </summary>
        public string extra_images { get; set; }

        /// <summary>
        ///  If true, this product is eligible for sale.
        /// </summary>
        public bool enabled { get; set; }

        /// <summary>
        /// If true, this product is promoted.
        /// </summary>
        public bool is_promoted { get; set; }

        /// <summary>
        ///  URL of the original image when product was created.
        /// </summary>
        public string original_image_url { get; set; }

        /// <summary>
        /// Date when product was created.
        /// </summary>
        public string date_uploaded { get; set; }

        /// <summary>
        ///  Time when product was last updated(%m-%d-%YT%H:%M:%S).
        /// </summary>
        public string last_updated { get; set; }

        /// <summary>
        /// If a product listing is enrolled in Wish Express this field will be a list of two letter country codes that the listing is eligible for
        /// </summary>
        public string wish_express_country_codes { get; set; }
    }
}
