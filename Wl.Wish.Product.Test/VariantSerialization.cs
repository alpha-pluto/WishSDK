using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Product.Test
{

    [TestClass]
    public class VariantSerialization
    {
        [TestMethod]
        public void TestComplexProductDownloadTaskDeserilization()
        {
            var json = "{'code': 0, 'data': {'Variant': {'enabled': 'True',                      'id': '529e6c2cf94aaa0cfe02846f',                      'inventory': '10',                      'price': '10',                      'shipping': '3',                      'size': '12',                      'sku': 'red-shoe-12'}}, 'message' : ''}";
            Wl.Wish.Product.Entities.VariantResult vr = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.VariantResult>(json);
            Console.Write(vr.data.Variant.id);
        }

        [TestMethod]
        public void TestComplexProductVariantListDeserilization()
        {
            var json = "{'code': 0, 'data': [{'Variant': {'enabled': 'True',                       'id': '5215451b31111f73ff2xxxxxx',                       'product_id' : '51e0a2c61111axxxcfffeyyy',                       'inventory': '1314',                       'msrp': '150.0',                       'price': '100.0',                       'shipping': '21.0',                       'sku': 'MMM'}},           {'Variant': {'color': 'blue',                        'enabled': 'True',                        'id': '5214c1111c238837cdiiiiii',                        'product_id' : '51e0a2c61111axxxcfffeyyy',                        'inventory': '917',                        'msrp': '100.0',                        'price': '50.0',                        'shipping': '9.81',                        'sku': 'DD1111'}}], 'message': '', 'paging': {'next': 'https://china-merchant.wish.com/api/v2/variant/multi-get?start=22&limit=2&access_token=an_example_access_token','previous': 'https://china-merchant.wish.com/api/v2/variant/multi-get?start=18&limit=2&access_token=an_example_access_token'}}";
            Wl.Wish.Product.Entities.VariantList vl = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.VariantList>(json);
            Console.Write(vl.data[1].Variant.inventory);
        }
    }
}
