/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OrderApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关订单的操作)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.HttpUtility;
using Wl.Wish.Product.CommonAPIs;

namespace Wl.Wish.Product.OrderAPIs
{
    public partial class OrderApi
    {
        #region 同步

        /// <summary>
        /// 获取订单
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#get-order
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderResult OrderRetrieve(string clientId, string accessToken, string orderId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId
                };

                var result = CommonJsonSend.Send<OrderResult>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取最近有变更的订单
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#list-all-orders
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="since"></param>
        /// <param name="wish_express_only"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderList OrdersRecentlyChangesRetrieve(string clientId, string accessToken, int start = 0, int limit = 50, string since = null, bool? wish_express_only = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/multi-get",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit,
                    since = since,
                    wish_express_only = wish_express_only
                };

                var result = CommonJsonSend.Send<OrderList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取未履约订单
        /// * 未履约订单  https://www.merchant.wish.com/documentation/api/v2#list-unfulfilled-orders
        /// 根据此处未履约订单的地址 为 https://china-merchant.wish.com/api/v2/order/get-fulfill
        /// 此处存疑
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#list-unfulfilled-orders
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="since"></param>
        /// <param name="wish_express_only"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderList OrdersUnfulfilledRetrieve(string clientId, string accessToken, int start = 0, int limit = 50, string since = null, bool? wish_express_only = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/get-fulfill",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit,
                    since = since,
                    wish_express_only = wish_express_only
                };

                var result = CommonJsonSend.Send<OrderList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 标记订单已履约
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#fulfill-an-order
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="trackingProvider">The carrier that will be shipping your package to its destination</param>
        /// <param name="trackingNumber">optional The unique identifier that your carrier provided so that the user can track their package as it is being delivered. Tracking number should only contain alphanumeric characters with no space between them.</param>
        /// <param name="ship_note">optional A note to yourself when you marked the order as shipped</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderResultBase OrderFulfill(string clientId, string accessToken, string orderId, string trackingProvider, string trackingNumber = null, string shipNote = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/fulfill-one",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    tracking_provider = trackingProvider,
                    tracking_number = trackingNumber,
                    ship_note = shipNote
                };

                var result = CommonJsonSend.Send<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 订单取消/退款
        /// ReasonCode 见 https://www.merchant.wish.com/documentation/api/v2#cancel-an-order
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#cancel-an-order
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="reasonCode"></param>
        /// <param name="reasonNote"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderResultBase OrderRefundOrCancel(string clientId, string accessToken, string orderId, Wl.Wish.Entities.ResonCodeOfRefundOrCancel reasonCode = Wish.Entities.ResonCodeOfRefundOrCancel.Other, string reasonNote = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/refund",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    reason_code = (int)reasonCode,
                    reason_note = reasonNote
                };

                var result = CommonJsonSend.Send<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改已发货订单的跟踪信息
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#update-tracking
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="trackingProvider"></param>
        /// <param name="trackingNumber"></param>
        /// <param name="shipNote"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderResultBase OrderShippedModifyTracking(string clientId, string accessToken, string orderId, string trackingProvider, string trackingNumber = null, string shipNote = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/modify-tracking",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    tracking_provider = trackingProvider,
                    tracking_number = trackingNumber,
                    ship_note = shipNote
                };

                var result = CommonJsonSend.Send<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改还未标记发货订单的收货信息
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#change-shipping
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="streetAddress2">可选 地址2</param>
        /// <param name="state">可选 州代码 </param>
        /// <param name="phoneNumber">可选 联系电话</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderResultBase OrderNotShippedModifyShippingInformation(string clientId, string accessToken, string orderId, string streetAddress1, string city, string zipCode, string country, string streetAddress2 = null, string state = null, string phoneNumber = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/change-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    street_address1 = streetAddress1,
                    city = city,
                    zipcode = zipCode,
                    country = country,
                    street_address2 = streetAddress2,
                    state = state,
                    phone_number = phoneNumber
                };

                var result = CommonJsonSend.Send<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 开始一个订单下载的任务 
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#order-create-download-job
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startDate">开始日期，形如 2017-01-01</param>
        /// <param name="endDate">结束日期，形如 2017-04-01</param>
        /// <param name="limitNumber"></param>
        /// <param name="sortNotation">排序方式 asc,desc</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderDownloadTask OrderDownload(string clientId, string accessToken, string startDate = null, string endDate = null, int? limitNumber = null, string sortNotation = "desc", SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/create-download-job",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startDate,
                    end = endDate,
                    limit = limitNumber,
                    sort = sortNotation
                };

                var result = CommonJsonSend.Send<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 查询订单下载任务状态
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderDownloadTask OrderDownloadQuery(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/get-download-job-status",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.Send<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 取消一个订单下载任务
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#order-cancel-download-job
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OrderDownloadTask OrderDownloadCancel(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/cancel-download-job",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.Send<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步

        /// <summary>
        /// 获取订单(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderResult> OrderRetrieveAsync(string clientId, string accessToken, string orderId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId
                };

                var result = CommonJsonSend.SendAsync<OrderResult>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取最近有变更的订单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="since"></param>
        /// <param name="wish_express_only"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderList> OrdersRecentlyChangesRetrieveAsync(string clientId, string accessToken, int start = 0, int limit = 50, string since = null, bool? wish_express_only = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/multi-get",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit,
                    since = since,
                    wish_express_only = wish_express_only
                };

                var result = CommonJsonSend.SendAsync<OrderList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取未履约订单 (异步)
        /// * 未履约订单  https://www.merchant.wish.com/documentation/api/v2#list-unfulfilled-orders
        /// 根据此处未履约订单的地址 为 https://china-merchant.wish.com/api/v2/order/get-fulfill
        /// 此处存疑
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="since"></param>
        /// <param name="wish_express_only"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderList> OrdersUnfulfilledRetrieveAsync(string clientId, string accessToken, int start = 0, int limit = 50, string since = null, bool? wish_express_only = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/get-fulfill",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit,
                    since = since,
                    wish_express_only = wish_express_only
                };

                var result = CommonJsonSend.SendAsync<OrderList>(token, url, data, CommonJsonSendType.GET);

                return result;


            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 标记订单已履约(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="trackingProvider">The carrier that will be shipping your package to its destination</param>
        /// <param name="trackingNumber">optional The unique identifier that your carrier provided so that the user can track their package as it is being delivered. Tracking number should only contain alphanumeric characters with no space between them.</param>
        /// <param name="ship_note">optional A note to yourself when you marked the order as shipped</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderResultBase> OrderFulfillAsync(string clientId, string accessToken, string orderId, string trackingProvider, string trackingNumber = null, string shipNote = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/fulfill-one",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    tracking_provider = trackingProvider,
                    tracking_number = trackingNumber,
                    ship_note = shipNote
                };

                var result = CommonJsonSend.SendAsync<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 订单取消/退款
        /// ReasonCode 见 https://www.merchant.wish.com/documentation/api/v2#cancel-an-order
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="reasonCode"></param>
        /// <param name="reasonNote"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderResultBase> OrderRefundOrCancelAsync(string clientId, string accessToken, string orderId, Wl.Wish.Entities.ResonCodeOfRefundOrCancel reasonCode = Wish.Entities.ResonCodeOfRefundOrCancel.Other, string reasonNote = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/refund",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    reason_code = (int)reasonCode,
                    reason_note = reasonNote
                };

                var result = CommonJsonSend.SendAsync<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;


            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改已发货订单的跟踪信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="trackingProvider"></param>
        /// <param name="trackingNumber"></param>
        /// <param name="shipNote"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderResultBase> OrderShippedModifyTrackingAsync(string clientId, string accessToken, string orderId, string trackingProvider, string trackingNumber = null, string shipNote = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/modify-tracking",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    tracking_provider = trackingProvider,
                    tracking_number = trackingNumber,
                    ship_note = shipNote
                };

                var result = CommonJsonSend.SendAsync<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改还未标记为发货的订单的收货信息 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="orderId"></param>
        /// <param name="streetAddress1"></param>
        /// <param name="city"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="state"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderResultBase> OrderNotShippedModifyShippingInformationAsync(string clientId, string accessToken, string orderId, string streetAddress1, string city, string zipCode, string country, string streetAddress2 = null, string state = null, string phoneNumber = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/change-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = orderId,
                    street_address1 = streetAddress1,
                    city = city,
                    zipcode = zipCode,
                    country = country,
                    street_address2 = streetAddress2,
                    state = state,
                    phone_number = phoneNumber
                };

                var result = CommonJsonSend.SendAsync<OrderResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 开始一个订单下载的任务 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startDate">开始日期，形如 2017-01-01</param>
        /// <param name="endDate">结束日期，形如 2017-04-01</param>
        /// <param name="limitNumber"></param>
        /// <param name="sortNotation">排序方式 asc,desc</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderDownloadTask> OrderDownloadAsync(string clientId, string accessToken, string startDate = null, string endDate = null, int? limitNumber = null, string sortNotation = "desc", SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/create-download-job",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startDate,
                    end = endDate,
                    limit = limitNumber,
                    sort = sortNotation
                };

                var result = CommonJsonSend.SendAsync<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 查询订单下载任务状态(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderDownloadTask> OrderDownloadQueryAsync(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/get-download-job-status",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.SendAsync<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 取消一个订单下载任务
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OrderDownloadTask> OrderDownloadCancelAsync(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/order/cancel-download-job",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.SendAsync<OrderDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion
    }
}
