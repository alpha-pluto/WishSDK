using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Product.Test
{
    [TestClass]
    public class EntitySerialization
    {
        [TestMethod]
        public void TestComplexProductEntityDeserilization()
        {
            var json = "{'code': 0, 'data':    {'Product': {'description': ' this is a cool shoe',                 'id': '52a11ebdf94adc0cfee0dbd9',                 'name': 'red shoe',                 'number_saves': '0',                 'number_sold': '0',                 'parent_sku': 'red-shoe',                 'review_status': 'pending',                 'tags': [{'Tag': {'id': 'red',                                   'name': 'red'}},                          {'Tag': {'id': 'cool',                                   'name': 'cool'}},                          {'Tag': {'id': 'shoe',                                   'name': 'shoe'}}],                  'variants': [{'Variant': {'enabled': 'True',                                            'id': '52a11ebef94adc0cfee0dbdb',                                            'product_id': '52a11ebdf94adc0cfee0dbd9',                                            'inventory': '100',                                            'price': '100.0',                                            'shipping': '10.0',                                            'shipping_time': '5-10',                                            'sku': 'red-shoe-11'}}]}}, 'message': ''}";

            Wl.Wish.Product.Entities.ProductResult pr = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductResult>(json);

            Console.Write(pr.data.Product.variants[0].Variant.id);
        }

        [TestMethod]
        public void TestComplexProductListEntityDeserilization()
        {
            var json = "{'code': 6, 'data': [{'Product': {'description': 'Example description',                       'id': '5284e18fb5baba49d5xxxxxx',                       'name': 'Cute Ring',                       'number_saves': '6',                       'number_sold': '0',                       'parent_sku': 'Cute Bow Ring',                       'review_status': 'approved',                       'tags': [{'Tag': {'id': 'womensring', 'name': 'womens ring'}},                                {'Tag': {'id': 'jewelry', 'name': 'Jewelry'}},                                {'Tag': {'id': 'bow', 'name': 'Bow'}}],                       'variants': [{'Variant': {'color': 'green',                                                 'enabled': 'True',                                                 'id': '5284e192b111ba49d5xxxxxx',                                                 'product_id': '5284e18fb5baba49d5xxxxxx',                                                 'inventory': '11',                                                 'msrp': '113.9',                                                 'price': '110.9',                                                 'shipping': '10.5',                                                 'sku': 'AA1'}},                                    {'Variant': {'color': 'blue',                                                 'enabled': 'True',                                                 'id': '5284e19qqqbaba49d5bbbbbb',                                                 'product_id': '5284e18fb5baba49d5xxxxxx',                                                 'inventory': '100',                                                 'msrp': '19.9',                                                 'price': '15.9',                                                 'shipping': '10.5',                                                 'sku': 'ZZ1'}}]}},           {'Product': {'description': 'Example Description',                         'id': '5284efafb5bab119d1zzzzzz',                         'name': 'Fairisle Scarf',                         'number_saves': '0',                         'number_sold': '0',                         'parent_sku': 'Fairisle Scarf',                         'review_status': 'rejected',                         'tags': [{'Tag': {'id': 'cottonscarf', 'name': 'cotton scarf'}},                                  {'Tag': {'id': 'fashionaccessorie', 'name': 'Fashion Accessories'}},                                  {'Tag': {'id': 'fashion', 'name': 'Fashion'}},                                  {'Tag': {'id': 'scarf', 'name': 'scarf'}}],                         'variants': [{'Variant': {'color': 'gray',                                                   'enabled': 'True',                                                   'id': '5284efb1b111ba49d1qqqqqq',                                                   'product_id': '5284efafb5bab119d1zzzzzz',                                                   'inventory': '1010',                                                   'msrp': '25.9',                                                   'price': '21.91',                                                   'shipping': '10.0',                                                   'sku': 'AA4'}},                                       {'Variant': {'color': 'red',                                                    'enabled': 'True',                                                    'id': '5284efbaaababa49d1eiwqdf',                                                    'product_id': '5284efafb5bab119d1zzzzzz',                                                    'inventory': '1100',                                                    'msrp': '21.99',                                                    'price': '21.91',                                                    'shipping': '11.0',                                                    'sku': 'AAB'}}]}}], 'message': '', 'paging': {'next': 'https://china-merchant.wish.com/api/v2/product/multi-get?start=22&limit=2&since=2014-10-15&access_token=an_example_access_token','previous': 'https://china-merchant.wish.com/api/v2/product/multi-get?start=18&limit=2&since=2014-10-15&access_token=an_example_access_token'}}";
            Wl.Wish.Product.Entities.ProductList pl = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductList>(json);
            Console.Write(pl.code);
        }

        [TestMethod]
        public void TestComplexProductShippingPriceSingleDeserilization()
        {
            var json = "{    'code': 0,    'data': {        'ProductCountryShipping': {            'country_code': 'CA',            'id': '123456789009876543211234',            'shipping_price': '3.00',            'use_product_shipping': 'False',            'enabled': 'True',            'wish_express': 'False'        }    },    'message': ''}";
            Wl.Wish.Product.Entities.ProductShippingPriceSingle psps = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductShippingPriceSingle>(json);
            Console.Write(psps.data.ProductCountryShipping.use_product_shipping);
        }

        [TestMethod]
        public void TestComplexProductShipingPriceMultipleDeserilization()
        {
            var json = "{'code': 0, 'data': {'ProductCountryAllShipping': {   'id': '123456789009876543211234',   'shipping_prices': [    {'ProductCountryShipping': {'country_code': 'AU',      'enabled': 'True',      'id': '123456789009876543211234',      'shipping_price': '1.0',      'use_product_shipping': 'False',      'wish_express': 'True'}},    {'ProductCountryShipping': {'country_code': 'CA',      'enabled': 'True',      'id': '123456789009876543211234',      'shipping_price': 'Use Product Shipping Price',      'use_product_shipping': 'True',      'wish_express': 'False'}},    {'ProductCountryShipping': {'country_code': 'GB',      'enabled': 'True',      'id': '123456789009876543211234',      'shipping_price': 'Use Product Shipping Price',      'use_product_shipping': 'True',      'wish_express': 'True'}},    {'ProductCountryShipping': {'country_code': 'US',      'enabled': 'True',      'id': '123456789009876543211234',      'shipping_price': '0.9',      'use_product_shipping': 'False',      'wish_express': 'False'}}]}}, 'message': ''}";
            Wl.Wish.Product.Entities.ProductShippingPriceMultiple pspm = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductShippingPriceMultiple>(json);
            Console.Write(pspm.data.ProductCountryAllShipping.shipping_prices[1].ProductCountryShipping.shipping_price);

        }

        [TestMethod]
        public void TestComplexProductShippingPriceMultipleOfManyDeserilization()
        {
            var json = "{'code': 0, 'data': [  {'ProductCountryAllShipping': {'id': '123456789009876543211234',    'shipping_prices': [     {'ProductCountryShipping': {'country_code': 'AU',       'enabled': 'True',       'id': '123456789009876543211234',       'shipping_price': '1.0',       'use_product_shipping': 'False',       'wish_express': 'True'}},     {'ProductCountryShipping': {'country_code': 'CA',       'enabled': 'True',       'id': '123456789009876543211234',       'shipping_price': 'Use Product Shipping Price',       'use_product_shipping': 'True',       'wish_express': 'True'}},     {'ProductCountryShipping': {'country_code': 'GB',       'enabled': 'True',       'id': '123456789009876543211234',       'shipping_price': 'Use Product Shipping Price',       'use_product_shipping': 'True',       'wish_express': 'False'}},     {'ProductCountryShipping': {'country_code': 'US',       'enabled': 'True',       'id': '123456789009876543211234',       'shipping_price': '0.9',       'use_product_shipping': 'False',       'wish_express': 'True'}}]}},  {'ProductCountryAllShipping': {'id': '111122223333444455556666',    'shipping_prices': [     {'ProductCountryShipping': {'country_code': 'AU',       'enabled': 'True',       'id': '111122223333444455556666',       'shipping_price': '1.0',       'use_product_shipping': 'False',       'wish_express': 'False'}},     {'ProductCountryShipping': {'country_code': 'CA',       'enabled': 'True',       'id': '111122223333444455556666',       'shipping_price': '2.0',       'use_product_shipping': 'False',       'wish_express': 'True'}},     {'ProductCountryShipping': {'country_code': 'GB',       'enabled': 'True',       'id': '111122223333444455556666',       'shipping_price': '3.0',       'use_product_shipping': 'False',       'wish_express': 'False'}},     {'ProductCountryShipping': {'country_code': 'US',       'enabled': 'True',       'id': '111122223333444455556666',       'shipping_price': 'Use Product Shipping Price',       'use_product_shipping': 'True',       'wish_express': 'False'}}]}}], 'message': ''}";
            Wl.Wish.Product.Entities.ProductShippingPriceMultipleOfMany pspmm = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductShippingPriceMultipleOfMany>(json);
            Console.Write(pspmm.data[0].ProductCountryAllShipping.shipping_prices[1].ProductCountryShipping.shipping_price);

        }

        [TestMethod]
        public void TestComplexProductShippingSettingsDeserilization()
        {
            var json = "{'code': 0, 'data': {'ShippingSetting': {'country_settings': [    {'CountryShippingSetting': {'country_code': 'AU',      'shipping_price': '1.00',      'use_product_shipping': 'False'}},    {'CountryShippingSetting': {'country_code': 'CA',      'shipping_price': '2.00',      'use_product_shipping': 'False'}},    {'CountryShippingSetting': {'country_code': 'GB',      'shipping_price': '3.00',      'use_product_shipping': 'False'}},    {'CountryShippingSetting': {'country_code': 'US',      'shipping_price': 'Use Product Shipping Price',      'use_product_shipping': 'True'}}],   'ships_worldwide': 'False'}}, 'message': ''}";
            Wl.Wish.Product.Entities.ProductShippingSettings pss = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductShippingSettings>(json);
            Console.Write(pss.data.ShippingSetting.country_settings[3].CountryShippingSetting.shipping_price);
        }

        [TestMethod]
        public void TestComplexProductDownloadTaskDeserilization()
        {
            var json = "{    'code': 0,    'data': {'job_id': '57bb5803ba2a1f181de31b01',  'status': 'FINISHED',        'total_count': 20553,        'processed_count': 20553,        'download_link': 'https://merchant.wish.com/static/sweeper-production-merchant-export/52f64e7aab980a038d62d61e-57bce38526778a33b3f8c375-2016-08-16-19:27:01.csv',        'created_date': '2016-08-18 02:40:25.238000',        'start_run_time': '2016-08-18 03:12:07.135000',        'end_run_time': '2016-08-18 02:49:28.798000'    },    'message': ''}";
            Wl.Wish.Product.Entities.ProductDownloadTask pdt = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.ProductDownloadTask>(json);
            Console.Write(pdt.data.download_link);
        }

    }
}
