/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ApiHandlerWapper.cs 
    文件功能描述：使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试
    
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;
using Wl.Wish.Exceptions;
using Wl.Wish.Product.Containers;
using Wl.Wish.Utilities.WishUtility;

namespace Wl.Wish.Product.CommonAPIs
{
    /// <summary>
    /// 针对AccessToken无效或过期的自动处理类
    /// </summary>
    public static class ApiHandlerWrapper
    {
        #region 同步方法

        /// <summary>
        /// 使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试。
        /// 使用此方法之前必须使用AccessTokenContainer.Register(_clientId, _clientSecret); 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <param name="clientId"></param>
        /// <param name="accessToken">AccessToken 如果为null，则自动取已经注册的第一个clientId/appSecret来信息获取AccessToken。</param>
        /// <param name="retryIfFaild">请保留默认值true，不用输入。</param>
        /// <returns></returns>
        public static T TryCommonApi<T>(Func<string, T> fun, string clientId = null, string accessToken = null, SessionType sessionType = SessionType.Prod, bool retryIfFaild = true) where T : WishJsonResult
        {

            if (clientId == null)
            {
                clientId = AccessTokenContainer.GetFirstOrDefaultClientId();
                if (clientId == null)
                {
                    throw new UnRegisterClientIdException(null,
                        "尚无已经注册的ClientId，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！");
                }
            }
            else
            {
                if (!AccessTokenContainer.CheckRegistered(clientId))
                {
                    throw new UnRegisterClientIdException(clientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", clientId));
                }
            }


            T result = null;

            try
            {

                if (accessToken == null)
                {
                    var accessTokenResult = AccessTokenContainer.GetAccessTokenResult(clientId, false, sessionType);
                    accessToken = accessTokenResult.data.access_token;
                }
                result = fun(accessToken);
            }
            catch (ErrorJsonResultException ex)
            {
                if (retryIfFaild
                    && clientId != null
                    && ex.JsonResult.code > 0)
                {
                    //尝试重新验证
                    //var accessTokenResult = AccessTokenContainer.GetAccessTokenResult(clientId, true);
                    var accessTokenResult = AccessTokenContainer.RefreshAccessTokenResult(clientId, sessionType);
                    //强制获取并刷新最新的AccessToken
                    accessToken = accessTokenResult.data.access_token;
                    result = TryCommonApi(fun, clientId, accessToken, sessionType, false);
                }
                else
                {
                    ex.ClientId = clientId;
                    throw;
                }
            }
            catch (WishException ex)
            {
                ex.ClientId = clientId;
                throw;
            }

            return result;
        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 【异步方法】使用AccessToken进行操作时，如果遇到AccessToken错误的情况，重新获取AccessToken一次，并重试。
        /// 使用此方法之前必须使用AccessTokenContainer.Register(_clientId, _clientSecret);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <param name="accessTokenOrClientId">AccessToken或ClientId。如果为null，则自动取已经注册的第一个clientId/appSecret来信息获取AccessToken。</param>
        /// <param name="retryIfFaild">请保留默认值true，不用输入。</param>
        /// <returns></returns>
        public static async Task<T> TryCommonApiAsync<T>(Func<string, Task<T>> fun, string clientId = null, string accessToken = null, SessionType sessionType = SessionType.Prod, bool retryIfFaild = true) where T : WishJsonResult
        {
            if (clientId == null)
            {
                clientId = AccessTokenContainer.GetFirstOrDefaultClientId();
                if (clientId == null)
                {
                    throw new UnRegisterClientIdException(null,
                        "尚无已经注册的ClientId，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！");
                }
            }
            else
            {
                if (!AccessTokenContainer.CheckRegistered(clientId))
                {
                    throw new UnRegisterClientIdException(clientId,
                        string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！",
                            clientId));
                }
            }



            Task<T> result = null;

            try
            {
                if (accessToken == null)
                {
                    var accessTokenResult = await AccessTokenContainer.GetAccessTokenResultAsync(clientId, false, sessionType);
                    accessToken = accessTokenResult.data.access_token;
                }
                result = fun(accessToken);
            }
            catch (ErrorJsonResultException ex)
            {
                if (retryIfFaild
                    && clientId != null
                    && ex.JsonResult.code > 0)
                {
                    //尝试重新验证
                    //var accessTokenResult = AccessTokenContainer.GetAccessTokenResultAsync(clientId, true, sessionType);
                    var accessTokenResult = AccessTokenContainer.RefreshAccessTokenResultAsync(clientId, sessionType);
                    //强制获取并刷新最新的AccessToken
                    accessToken = accessTokenResult.Result.data.access_token;
                    result = TryCommonApiAsync(fun, clientId, accessToken, sessionType, false);
                }
                else
                {
                    throw;
                }
            }

            return await result;
        }

        #endregion

    }
}
