/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：TicketApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关ticket的操作)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.CommonAPIs;
using Wl.Wish.Product.Entities;

namespace Wl.Wish.Product.TicketAPIs
{
    public partial class TicketApi
    {
        #region 同步 

        /// <summary>
        /// 获取一个Ticket
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-ticket
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketResult TicketRetrieve(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.Send<TicketResult>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取所有等待回复的Ticket
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#list-tickets
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startNumber"></param>
        /// <param name="limitNumber"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketList TicketRetrieveAll(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/get-action-required",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.Send<TicketList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 回复Ticket
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#reply-ticket
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="replyContent"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketResultBase TicketReply(string clientId, string accessToken, string ticketId, string replyContent = "", SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/reply",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId,
                    reply = replyContent
                };

                var result = CommonJsonSend.Send<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 关闭一个Ticket
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#close-ticket
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketResultBase TicketClose(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/close",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.Send<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 就某个Ticket 请求Wish 的支持
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#appeal-ticket
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketResultBase TicketAppealWishSupport(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/appeal-to-wish-support",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.Send<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 重新开启一个Ticket
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#reopen-ticket
        /// 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="reasonToReOpen">重新开启的原因</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static TicketResultBase TicketReOpen(string clientId, string accessToken, string ticketId, string reasonToReOpen, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/ticket/re-open",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId,
                    reply = reasonToReOpen
                };

                var result = CommonJsonSend.Send<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;


            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步

        /// <summary>
        /// 获取一个Ticket(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketResult> TicketRetrieveAsync(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.SendAsync<TicketResult>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取所有等待回复的Ticket ( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="startNumber"></param>
        /// <param name="limitNumber"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketList> TicketRetrieveAllAsync(string clientId, string accessToken, int startNumber = 0, int limitNumber = 50, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/get-action-required",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = startNumber,
                    limit = limitNumber
                };

                var result = CommonJsonSend.SendAsync<TicketList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 回复Ticket（异步）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="replyContent"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketResultBase> TicketReplyAsync(string clientId, string accessToken, string ticketId, string replyContent = "", SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/reply",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId,
                    reply = replyContent
                };

                var result = CommonJsonSend.SendAsync<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 关闭一个Ticket ( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketResultBase> TicketCloseAsync(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/close",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.SendAsync<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 就某个Ticket 请求Wish 的支持( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketResultBase> TicketAppealWishSupportAsync(string clientId, string accessToken, string ticketId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/ticket/appeal-to-wish-support",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId
                };

                var result = CommonJsonSend.SendAsync<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 重新开启一个Ticket ( 异步 )
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="ticketId"></param>
        /// <param name="reasonToReOpen">重新开启的原因</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<TicketResultBase> TicketReOpenAsync(string clientId, string accessToken, string ticketId, string reasonToReOpen, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/ticket/re-open",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = ticketId,
                    reply = reasonToReOpen
                };

                var result = CommonJsonSend.SendAsync<TicketResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion
    }
}
