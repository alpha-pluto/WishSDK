using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Test
{
    [TestClass]
    public class EntitySerialization
    {
        [TestMethod]
        public void TestComplexProductEntitySerilization()
        {
            var serializerHelper = new Wl.Wish.Helpers.SerializerHelper();
            var cp = new Wl.Wish.Entities.Response.Product();
            cp.brand = "xbull";
            cp.date_uploaded = DateTime.Now.AddDays(-2).ToString();
            cp.description = "good";
            cp.enabled = true;
            cp.extra_images = "//v.c/a.jpg|//v.c/b.jpg|//v.c/d.jpg";
            cp.id = "baba-2016";
            cp.is_promoted = false;
            cp.landing_page_url = "//v.c/p/3232323.html";
            cp.last_updated = DateTime.Now.ToString();
            cp.main_image = "//v.c/ff.jpg";
            cp.name = "product name";
            cp.number_saves = 30;
            cp.number_sold = 300;
            cp.original_image_url = "//v.c/ticket.jpg";
            cp.parent_sku = "baba-2016-population";
            cp.review_status = "approved";
            cp.tags = new System.Collections.Generic.List<Entities.Response.TagWrapper>();
            cp.tags.Add(new Entities.Response.TagWrapper() { Tag = new Entities.Response.TagEntity { id = "blue", name = "blue" } });
            cp.tags.Add(new Entities.Response.TagWrapper() { Tag = new Entities.Response.TagEntity { id = "red", name = "red" } });
            cp.tags.Add(new Entities.Response.TagWrapper() { Tag = new Entities.Response.TagEntity { id = "yellow", name = "yellow" } });
            cp.tags.Add(new Entities.Response.TagWrapper() { Tag = new Entities.Response.TagEntity { id = "cygn", name = "cygn" } });

            cp.upc = "123456789abc";
            cp.variants = new System.Collections.Generic.List<Entities.Response.VariantWrapper>();
            cp.variants.Add(new Entities.Response.VariantWrapper { Variant = new Entities.Response.VariantEntity { id = "232223232dfee", all_images = "//v.c/a.jpg|//v.c/g.jpg", color = "blue", enabled = true, inventory = 100, msrp = 123.00m, price = 120.00m, product_id = "afddfdf", shipping = 20.00m, shipping_time = "5-15", size = "size", sku = "baba-2016-population-blue" } });
            cp.variants.Add(new Entities.Response.VariantWrapper { Variant = new Entities.Response.VariantEntity { id = "232223232sdfds", all_images = "//v.c/a.jpg|//v.c/g.jpg", color = "red", enabled = true, inventory = 100, msrp = 123.00m, price = 120.00m, product_id = "afddfdf", shipping = 20.00m, shipping_time = "5-15", size = "size", sku = "baba-2016-population-red" } });
            cp.variants.Add(new Entities.Response.VariantWrapper { Variant = new Entities.Response.VariantEntity { id = "232223232dfds", all_images = "//v.c/a.jpg|//v.c/g.jpg", color = "yellow", enabled = true, inventory = 100, msrp = 123.00m, price = 120.00m, product_id = "afddfdf", shipping = 20.00m, shipping_time = "5-15", size = "size", sku = "baba-2016-population-yellow" } });
            cp.variants.Add(new Entities.Response.VariantWrapper { Variant = new Entities.Response.VariantEntity { id = "232223232we2f", all_images = "//v.c/a.jpg|//v.c/g.jpg", color = "green", enabled = true, inventory = 100, msrp = 123.00m, price = 120.00m, product_id = "afddfdf", shipping = 20.00m, shipping_time = "5-15", size = "size", sku = "baba-2016-population-green" } });
            cp.wish_express_country_codes = "CN";

            var jsonString = serializerHelper.GetJsonString(cp, null);

            Console.Write(jsonString);

        }

        [TestMethod]
        public void TestProductShippingEditMultiple()
        {
            var serializerHelper = new Wl.Wish.Helpers.SerializerHelper();
            var psm = new Wl.Wish.Entities.Request.ProductShippingPriceMultiple();
            psm.id = "a1232d2fe342342";
            psm.HU = 4.00m;
            psm.AE = 12.00m;
            psm.use_product_shipping_countries = "GB,IT";
            psm.disabled_countries = "MX,BR";
            psm.wish_express_add_countries = "FR,ES";
            psm.wish_express_remove_countries = "US,CA";

            //var jsonString = serializerHelper.GetJsonString(psm, null);

            StringBuilder sbQueryString = new StringBuilder();
            foreach (System.Reflection.PropertyInfo p in psm.GetType().GetProperties())
            {
                sbQueryString.Append("&" + p.Name + "=" + Convert.ToString(p.GetValue(psm)));
            }

            var queryString = sbQueryString.ToString();
            queryString = queryString.Substring(1, queryString.Length - 1);
            Console.Write(queryString);
            //Console.Write(jsonString);
        }
    }
}
