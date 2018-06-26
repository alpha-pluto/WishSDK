/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：NotificationApi.cs
    文件功能描述：Notification API  

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.Product.CommonAPIs;

namespace Wl.Wish.Product.NotificationAPIs
{
    public partial class NotificationApi
    {
        #region 同步

        /// <summary>
        /// 获取未查看的通知消息
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#noti-fetch
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startNumber"></param>
        /// <param name="limitNumber"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static NotificationList NotificationUnviewedRetrieve(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/fetch-unviewed",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.Send<NotificationList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 标记通知为已读
        /// 参数中的noti_id 在
        /// https://www.merchant.wish.com/documentation/api/v2#noti-mark
        /// 中示例为id
        /// 但是在 
        /// https://www.merchant.wish.com/documentation/api/explorer/noti/mark-as-viewed
        /// 中为noti_id
        /// 此处对参数存疑问
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="notificationId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static NotificationResultBase NotificationMarkViewed(string clientId, string accessToken, string notificationId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/mark-as-viewed",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    noti_id = notificationId
                };

                var result = CommonJsonSend.Send<NotificationResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取未查看通知的条数
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#noti-count
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static NotificationResultBase NotificationUnviewedCountRetrieve(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/get-unviewed-count",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<NotificationResultBase>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取公告
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#fetch-bd-announcements
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static AnnouncementList AnnouncementRetrieve(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/fetch-bd-announcement",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<AnnouncementList>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取系统更改通知
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#fetch-system-updates-noti
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static SystemUpdateNotification SystemUpdateNotificationRetrieve(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/fetch-sys-updates-noti",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<SystemUpdateNotification>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取违规通知列表 
        /// </summary>
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#fetch-infractions
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static InfractionList InfractionListRetrieve(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/get/infractions",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.Send<InfractionList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取违规通知次数
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#get-infraction-count
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static CountInfractionsResult InfractionCountRetrieve(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/count/infractions",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<CountInfractionsResult>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步

        /// <summary>
        /// 获取未查看的通知消息(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startNumber"></param>
        /// <param name="limitNumber"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<NotificationList> NotificationUnviewedRetrieveAsync(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/fetch-unviewed",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.SendAsync<NotificationList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 标记通知为已读 ( 异步 )
        /// 参数中的noti_id 在
        /// https://www.merchant.wish.com/documentation/api/v2#noti-mark
        /// 中示例为id
        /// 但是在 
        /// https://www.merchant.wish.com/documentation/api/explorer/noti/mark-as-viewed
        /// 中为noti_id
        /// 此处对参数存疑问
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="notificationId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<NotificationResultBase> NotificationMarkViewedAsync(string clientId, string accessToken, string notificationId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/mark-as-viewed",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    noti_id = notificationId
                };

                var result = CommonJsonSend.SendAsync<NotificationResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取未查看通知的条数 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<NotificationResultBase> NotificationUnviewedCountRetrieveAsync(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/noti/get-unviewed-count",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<NotificationResultBase>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取公告(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<AnnouncementList> AnnouncementRetrieveAsync(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {

                var url =
                   string.Format("{0}/api/v2/fetch-bd-announcement",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<AnnouncementList>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取系统更改通知 ( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<SystemUpdateNotification> SystemUpdateNotificationRetrieveAsync(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                      string.Format("{0}/api/v2/fetch-sys-updates-noti",
                                  sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<SystemUpdateNotification>(token, url, null, CommonJsonSendType.GET);

                return result;


            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取违规通知列表 ( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<InfractionList> InfractionListRetrieveAsync(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/get/infractions",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.SendAsync<InfractionList>(token, url, data, CommonJsonSendType.GET);

                return result;


            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取违规通知次数 (异步)
        /// 
        /// 请求原始文档
        /// > curl "https://china-merchant.wish.com/api/v2/count/infractions?access_token=an_example_access_token"
        /// 返回数据原始文档：
        /// {
        ///     u 'message': u '', u 'code': 0, u 'data': {
        ///         u 'CountInfractionsResponse': {
        ///             u 'count': u '156'
        ///         }
        ///     }
        /// }
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<CountInfractionsResult> InfractionCountRetrieveAsync(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/count/infractions",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<CountInfractionsResult>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion
    }
}
