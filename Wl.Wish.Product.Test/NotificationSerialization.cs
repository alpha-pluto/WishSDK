
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Product.Test
{
    /// <summary>
    /// NotificationSerialization 的摘要说明
    /// </summary>
    [TestClass]
    public class NotificationSerialization
    {
        [TestMethod]
        public void TestNotificationListSerialization()
        {
            var json = "{'message':'','code':0,'data':[{'GetNotiResponse':{    'perma_link':'http://merchant.wish.com/release/57180d6c49xxxxxxxxxxxxxx',    'message':'Sizing Chart XXXXX',    'id':'571810da7exxxxxxxxxxxxxx',    'title':'There is a new xxxxxxxxxx'}},{'GetNotiResponse':{    'perma_link':'http://merchant.wish.com/release/57180d6c49xxxxxxxxxxxxxx',    'message':'Sizing Chart XXXXX',    'id':'571812abf9xxxxxxxxxxxxxx',    'title':'There is a new xxxxxxxxxx'}}],'paging':{'next':'https://merchant.wish.com/api/v2/noti/fetch-unviewed?start=12','previous':'https://merchant.wish.com/api/v2/noti/fetch-unviewed?start=8'}}";
            Wl.Wish.Product.Entities.NotificationList tl = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.NotificationList>(json);
            Console.Write(tl.data[0].GetNotiResponse.perma_link);
        }

        [TestMethod]
        public void TestSystemUpdateNotificationSerialization()
        {
            var json = "{    'message': '', 'code': 0, 'data': [{        'SystemUpdatesResponse': {            'release_date': 'Thursday May 19, 2016',            'id': '573e46218db5d1487ee4bdd8',            'features': [{                'Feature': {                    'cn_title': '\u5173\u4e8e\u66f4\u65b0\u6bcf\u4e2a\u4ea7\u54c1\u56fd\u9645\u8fd0\u8d39\u7684\u65b0\u529f\u80fd',                    'body': 'We are very excited to announce that you can set international shipping prices per product now. No matter what sizes and weights your products are or what countries you are shipping to, you can always set shipping prices accordingly. You can start with changing overall default shipping prices on shipping settings page. Next step is to update per product shipping prices for specific countries by updating manually or a CSV file.\n\nFor a step to step guide, please visit our FAQ page for more information:',                    'title': 'New Feature About Updating International Shipping Prices Per Product',                    'link': 'http://merchantfaq.wish.com/hc/en-us/articles/218812008',                    'cn_body': '\u5c0a\u656c\u7684\u5546\u6237\uff0c\n\n\u6211\u4eec\u975e\u5e38\u8363\u5e78\u7684\u901a\u77e5\u60a8\uff0c\u60a8\u73b0\u5728\u53ef\u4ee5\u7ed9\u6bcf\u4e2a\u4ea7\u54c1\u9488\u5bf9\u4e0d\u540c\u56fd\u5bb6\u6765\u8bbe\u7f6e\u4e0d\u540c\u8fd0\u8d39\u4e86\u3002\u65e0\u8bba\u60a8\u7684\u4ea7\u54c1\u662f\u4ec0\u4e48\u5c3a\u5bf8\u548c\u91cd\u91cf\u6216\u8005\u8981\u5bc4\u5f80\u54ea\u4e9b\u56fd\u5bb6\uff0c\u60a8\u603b\u53ef\u4ee5\u6839\u636e\u4e0d\u540c\u7684\u4ea7\u54c1\u8bbe\u5b9a\u90ae\u8d39\u3002\u64cd\u4f5c\u65b9\u6cd5\u5982\u4e0b\uff0c\u60a8\u53ef\u4ee5\u5148\u4f7f\u7528\u914d\u9001\u8bbe\u7f6e\u9875\u9762\u6765\u8bbe\u7f6e\u6bcf\u4e2a\u56fd\u5bb6\u7684\u9ed8\u8ba4\u8fd0\u8d39\uff0c\u518d\u53bb\u4ea7\u54c1\u4e00\u89c8\u9875\u9762\u6839\u636e\u4e0d\u540c\u7684\u56fd\u5bb6\u66f4\u6539\u6bcf\u4e2a\u4ea7\u54c1\u7684\u8fd0\u8d39\uff0c\u53ef\u4ee5\u624b\u52a8\u4fee\u6539\u6216\u8005\u4e0a\u4f20CSV\u6587\u4ef6\u3002 \n\n\u5982\u679c\u60a8\u60f3\u8981\u83b7\u53d6\u66f4\u591a\u4fe1\u606f\u548c\u5177\u4f53\u64cd\u4f5c\u6b65\u9aa4\uff0c\u8bf7\u8bbf\u95ee\u5e38\u89c1\u95ee\u9898:',                    'cn_link': 'http://merchantfaq.wish.com/hc/zh-cn/articles/218812008'                }            }]        }    }, {        'SystemUpdatesResponse': {            'release_date': 'Monday August 03, 2015',            'id': '55bfae216daddd41f93512ce',            'features': [{                'Feature': {                    'cn_title': '\u5546\u6237APP(Android)\u6700\u65b0\u4e0a\u7ebf',                    'body': 'We are happy to announce a new mobile app for merchants. This app will be released initially on Android and will allow merchants to keep up to date with the latest metrics about their store. The app will also enable you to get the latest system updates and notifications right to your phone.\n\nGet the app from Google play, Xiaomi store, or direct download here: ',                    'title': 'Announcing New Merchant Android App',                    'link': 'http://merchant.wish.com/mobile',                    'cn_body': '\u6211\u4eec\u5f88\u9ad8\u5174\u5730\u5ba3\u5e03\uff1aWish\u5546\u6237APP\u4e0a\u7ebf\u4e86\u3002\u8be5APP\u4f1a\u9996\u5148\u5728\u5b89\u5353\u7cfb\u7edf\u4e0a\u7ebf, \u8ba9\u5e7f\u5927\u5546\u6237\u5728\u624b\u673a\u4e0a\u4fbf\u80fd\u67e5\u770b\u5e97\u94fa\u5185\u7684\u6700\u65b0\u6570\u636e\u52a8\u6001\uff0c\u4e86\u89e3\u6700\u65b0\u7684\u7cfb\u7edf\u66f4\u65b0\uff0c\u5e76\u6536\u5230\u66f4\u65b0\u4fe1\u606f\u7684\u53ca\u65f6\u901a\u77e5\u3002\n\n\u8bf7\u4eceGoogle play\uff0cXiaomi\u5e94\u7528\u5546\u5e97\u4e0b\u8f7d\u3002\u4e5f\u53ef\u76f4\u63a5\u70b9\u51fb\u4ee5\u4e0b\u94fe\u63a5\u4e0b\u8f7d\uff1a',                    'cn_link': 'http://merchant.wish.com/mobile'                }            }]        }    }]}";
            Wl.Wish.Product.Entities.SystemUpdateNotification sun = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.SystemUpdateNotification>(json);
            Console.Write(sun.data[0].SystemUpdatesResponse.features[0].Feature.link);
        }

        [TestMethod]
        public void TestInfractionListSerialization()
        {
            var json = "{    'message': '', 'code': 0, 'data': {        'InfractionsResponse': {            'infractions': [{                'Infraction': {                    'link': 'https://merchant.wish.com/warning/view/5475d08d6fa88c67d5416fb9',                    'id': '5475d08d6fa88cxxxxxxxxxx'                }            }, {                'Infraction': {                    'link': 'https://merchant.wish.com/warning/view/547720da6fa88cXXXXXXXXXX',                    'id': '547720da6fa88cXXXXXXXXXX'                }            }, {                'Infraction': {                    'link': 'https://merchant.wish.com/warning/view/547872746fa88cXXXXXXXXXX',                    'id': '547872746fa88cXXXXXXXXXX'                }            }, {                'Infraction': {                    'link': 'https://merchant.wish.com/warning/view/5479c3dc6fa88cXXXXXXXXXX',                    'id': '5479c3dc6fa88cXXXXXXXXXX'                }            }, {                'Infraction': {                    'link': 'https://merchant.wish.com/warning/view/5479c3e16fa88cXXXXXXXXXX',                    'id': '5479c3e16fa88cXXXXXXXXXX'                }            }]        }    }, 'paging': {        'next': 'https://merchant.wish.com/api/v2/get/infractions?access_token=57685a3d1ce64a5479c3e16fa88cXXXXXXXXXX&start=5'    }}";
            Wl.Wish.Product.Entities.InfractionList il = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.InfractionList>(json);
            Console.Write(il.data.InfractionsResponse.infractions[0].Infraction.link);
        }

        [TestMethod]
        public void TestInfractionResultSerialization()
        {
            var json = "{    'message': '', 'code': 0, 'data': {        'CountInfractionsResponse': {            'count': '156'        }    }}";
            Wl.Wish.Product.Entities.CountInfractionsResult cir = Wl.Wish.HttpUtility.Post.GetResult<Wl.Wish.Product.Entities.CountInfractionsResult>(json);
            Console.Write(cir.data.CountInfractionsResponse.count);
        }
    }
}
