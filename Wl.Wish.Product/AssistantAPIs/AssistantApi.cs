/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：AssistantApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关商品的辅助操作，如下载 )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.HttpUtility;
using Wl.Wish.Product.CommonAPIs;

namespace Wl.Wish.Product.AssistantAPIs
{
    public partial class AssistantApi
    {
        #region 同步

        /// <summary>
        /// 开始批量下载商品的任务
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#product-create-download-job
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sinceDate"></param>
        /// <param name="limitNum"></param>
        /// <param name="sortString"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductDownloadTask ProductDownloadTaskStart(string clientId, string accessToken, string sinceDate, int? limitNum, string sortString, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/create-download-job",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    since = sinceDate,
                    limit = limitNum
                };

                var result = CommonJsonSend.Send<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 查询商品下载任务的状态
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#product-get-download-job-status
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductDownloadTask ProductDownloadTaskStatusQuery(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-download-job-status",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.Send<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 取消商品下载任务
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#product-cancel-download-job
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductDownloadTask ProductDownloadTaskCancel(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/cancel-download-job",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.Send<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步

        /// <summary>
        /// 开始批量下载商品的任务(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sinceDate"></param>
        /// <param name="limitNum"></param>
        /// <param name="sortString"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductDownloadTask> ProductDownloadTaskStartAsync(string clientId, string accessToken, string sinceDate, int? limitNum, string sortString, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/create-download-job",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    since = sinceDate,
                    limit = limitNum
                };

                var result = CommonJsonSend.SendAsync<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 查询商品下载任务的状态 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductDownloadTask> ProductDownloadTaskStatusQueryAsync(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-download-job-status",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.SendAsync<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 取消商品下载任务(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="jobId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductDownloadTask> ProductDownloadTaskCancelAsync(string clientId, string accessToken, string jobId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/cancel-download-job",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    job_id = jobId
                };

                var result = CommonJsonSend.SendAsync<ProductDownloadTask>(token, url, data, CommonJsonSendType.POST);

                return result;


            }, clientId, accessToken, sessionType);
        }

        #endregion
    }
}
