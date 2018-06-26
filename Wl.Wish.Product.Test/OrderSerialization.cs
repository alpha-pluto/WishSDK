using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Product.Test
{
    /// <summary>
    /// OrderSerialization 的摘要说明
    /// </summary>
    [TestClass]
    public class OrderSerialization
    {

        [TestMethod]
        public void TestComplexOrderEntityDeserilization()
        {
            var json = "{'code': 0, 'data': {'Order': {'ShippingDetail': {'city': 'North Bay',                                       'country': 'US',                                       'name': 'Mick Berry',                                       'phone_number': '+1 555-181-7247',                                       'state': 'NC',                                       'street_address1': '2126 PO Box 5 Rt 49',                                       'zipcode': '13123'},                      'last_updated': '2013-12-06T20:20:20',                      'order_time': '2013-12-06T20:20:20',                      'order_id': '123456789009876543210164',                      'order_total': '17.6',                      'product_id': '1113fad43deaf71536cb2c74',                      'buyer_id': '1234fad43deaf71536cb2c74',                      'quantity': '2',                      'price':'8',                      'cost':'6.8',                      'shipping':'2.35',                      'shipping_cost':'2',                      'product_name':'Dandelion Necklace',                      'product_image_url':'http://d1zog42tnv26ho.cloudfront.net/4fea11fac43bf532f4001419-normal.jpg',                      'days_to_fulfill': '2',                      'hours_to_fulfill': '49',                      'sku': 'Dandelion Necklace',                      'state': 'APPROVED',                      'transaction_id': '11114026a99e980d4e500269',                      'tracking_confirmed': 'True',                      'tracking_confirmed_date': '2013-12-13T05:07:12',                      'variant_id': '1111fad63deaf71536cb2c76'}}, 'message': ''}";

            Wl.Wish.Product.Entities.OrderResult or = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.OrderResult>(json);

            Console.Write(or.data.Order.buyer_id);
        }

        [TestMethod]
        public void TestComplexOrderListDeserilization()
        {
            var json = "{'code': 0, 'data': [{'Order': {'ShippingDetail': {'city': 'New York City',                                        'country': 'US',                                        'name': 'Guadalupe Smith',                                        'phone_number': '5554191609',                                        'state': 'California',                                        'street_address1': '3317 w 51st Street',                                        'zipcode': '60632'},                      'last_updated': '2014-01-20T20:20:20',                      'order_time': '2014-01-20T20:20:20',                      'order_id': '123456789009876543210164',                      'order_total': '17.6',                      'product_id': '1113fad43deaf71536cb2c74',                      'buyer_id': '1234fad43deaf71536cb2c74',                      'quantity': '2',                      'price':'8',                      'cost':'6.8',                      'shipping':'2.35',                      'shipping_cost':'2',                      'product_name':'Dandelion Necklace',                      'product_image_url':'http://d1zog42tnv26ho.cloudfront.net/4fea11fac43bf532f4001419-normal.jpg',                      'days_to_fulfill': '2',                      'hours_to_fulfill': '49',                      'sku': 'Dandelion Necklace',                      'state': 'APPROVED',                      'transaction_id': '11114026a99e980d4e500269',                      'variant_id': '1111fad63deaf71536cb2c76'}},           {'Order': {'ShippingDetail': {'city': 'Lake City',                                         'country': 'US',                                         'name': 'Marko Schroeder',                                         'phone_number': '+1 555-399-7785',                                         'state': 'NY',                                         'street_address1': '20685 W Verona Ave',                                         'zipcode': '60046'},                       'last_updated': '2014-01-20T20:20:20',                       'order_time': '2014-01-20T20:20:20',                       'order_id': '1114a7cfb2ec2d42d272b627',                       'order_total': '17.6',                      'product_id': '1113fad43deaf71536cb2c74',                      'buyer_id': '1234fad43deaf71536cb2c74',                      'quantity': '2',                      'price':'8',                      'cost':'6.8',                      'shipping':'2.35',                      'shipping_cost':'2',                      'product_name':'Dandelion Necklace',                      'product_image_url':'http://d1zog42tnv26ho.cloudfront.net/4fea11fac43bf532f4001419-normal.jpg',                      'days_to_fulfill': '2',                      'hours_to_fulfill': '2',                      'sku': 'Dandelion Necklace',                      'state': 'APPROVED',                      'transaction_id': '11114026a99e980d4e500269',                      'tracking_confirmed': 'True',                      'tracking_confirmed_date': '2013-12-13T05:07:12',                      'variant_id': '1111fad63deaf71536cb2c76'}}], 'message': '', 'paging': {'next': 'https://china-merchant.wish.com/api/v2/order/multi-get??start=300&limit=100&since=2014-01-20&access_token=an_example_access_token','previous': 'https://china-merchant.wish.com/api/v2/order/multi-get?start=100&limit=100&since=2014-01-20&access_token=an_example_access_token'}}";
            Wl.Wish.Product.Entities.OrderList ol = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.OrderList>(json);
            Console.Write(ol.paging.previous);
        }

        [TestMethod]
        public void TestComplexOrderListUnfulfilledDeserilization()
        {
            var json = "{'code': 0, 'data': [{'Order': {'ShippingDetail': {'city': 'New York City',                                        'country': 'US',                                        'name': 'Guadalupe Smith',                                        'phone_number': '5554191609',                                        'state': 'California',                                        'street_address1': '3317 w 51st Street',                                        'zipcode': '60632'},                      'last_updated': '2014-01-20T20:20:20',                      'order_time': '2014-01-20T20:20:20',                      'order_id': '123456789009876543210164',                      'order_total': '17.6',                      'product_id': '1113fad43deaf71536cb2c74',                      'buyer_id': '1234fad43deaf71536cb2c74',                      'quantity': '2',                      'price':'8',                      'cost':'6.8',                      'shipping':'2.35',                      'shipping_cost':'2',                      'product_name':'Dandelion Necklace',                      'product_image_url':'http://d1zog42tnv26ho.cloudfront.net/4fea11fac43bf532f4001419-normal.jpg',                      'days_to_fulfill': '2',                      'hours_to_fulfill': '49',                      'sku': 'Dandelion Necklace',                      'state': 'APPROVED',                      'transaction_id': '11114026a99e980d4e500269',                      'variant_id': '1111fad63deaf71536cb2c76'}},           {'Order': {'ShippingDetail': {'city': 'Lake City',                                         'country': 'US',                                         'name': 'Marko Schroeder',                                         'phone_number': '+1 555-399-7785',                                         'state': 'NY',                                         'street_address1': '20685 W Verona Ave',                                         'zipcode': '60046'},                       'last_updated': '2014-01-20T20:20:20',                       'order_time': '2014-01-20T20:20:20',                       'order_id': '1114a7cfb2ec2d42d272b627',                       'order_total': '17.6',                      'product_id': '1113fad43deaf71536cb2c74',                      'buyer_id': '1234fad43deaf71536cb2c74',                      'quantity': '2',                      'price':'8',                      'cost':'6.8',                      'shipping':'2.35',                      'shipping_cost':'2',                      'product_name':'Dandelion Necklace',                      'product_image_url':'http://d1zog42tnv26ho.cloudfront.net/4fea11fac43bf532f4001419-normal.jpg',                      'days_to_fulfill': '2',                      'hours_to_fulfill': '49',                      'sku': 'Dandelion Necklace',                      'state': 'APPROVED',                      'transaction_id': '11114026a99e980d4e500269',                      'variant_id': '1111fad63deaf71536cb2c76'}}], 'message': '', 'paging': {'next': 'https://china-merchant.wish.com/api/v2/order/get-fulfill?start=100&limit=100&access_token=an_example_access_token'}}";

            Wl.Wish.Product.Entities.OrderList ol = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.OrderList>(json);
            Console.Write(ol.data[0].Order.state);
        }

        [TestMethod]
        public void TestSimpleOrderDownloadEntityDeserilization()
        {
            var json = "{    'code': 0,    'data': {'job_id': '57bb5803ba2a1f181de31b01'},    'message': ''}";

            Wl.Wish.Product.Entities.OrderDownloadTask odt = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.OrderDownloadTask>(json);
            Console.Write(odt.data.job_id);
        }

        [TestMethod]
        public void TestComplexOrderDeserilization()
        {
            var json = "{    'code': 0,    'data': {        'status': 'FINISHED',        'total_count': 20553,        'processed_count': 20553,        'download_link': 'https://merchant.wish.com/static/sweeper-production-merchant-export/52f64e7aab980a038d62d61e-57bce38526778a33b3f8c375-2016-08-16-19:27:01.csv',        'created_date': '2016-08-18 02:40:25.238000',        'start_run_time': '2016-08-18 03:12:07.135000',        'end_run_time': '2016-08-18 02:49:28.798000' ,  },    'message': ''}";
            //Wl.Wish.Product.Entities.OrderDownloadTask odt = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.OrderDownloadTask>(json);
            Wl.Wish.Product.Entities.OrderDownloadTask odt = Wl.Wish.Utilities.JsonUtility.Deserialize<Wl.Wish.Product.Entities.OrderDownloadTask>(json);
            Console.Write(odt.data.download_link);
        }

    }
}
