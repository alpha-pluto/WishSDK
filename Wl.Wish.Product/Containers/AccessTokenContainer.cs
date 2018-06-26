/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：AccessTokenContainer.cs
    文件功能描述：通用接口AccessToken容器，用于自动管理AccessToken，如果过期会重新获取

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Containers;
using Wl.Wish.Product.Entities;
using Wl.Wish.CacheUtility;
using Wl.Wish.Exceptions;
using Wl.Wish.Product.CommonAPIs;
using Wl.Wish.Utilities.WishUtility;
namespace Wl.Wish.Product.Containers
{
    public class AccessTokenBag : BaseContainerBag, IBaseContainerBag_ClientId
    {
        #region parameter

        private string _clientId;
        private string _clientSecret;
        private string _appName;
        private string _preCode;
        private string _redirectUri;
        private DateTime _accessTokenExpireTime;
        private AccessTokenResult _accessTokenResult;


        #endregion

        /// <summary>
        /// AppName
        /// </summary>
        public string AppName
        {
            get { return _appName; }
            set { base.SetContainerProperty(ref _appName, value); }
        }

        /// <summary>
        /// ClientId
        /// </summary>
        public string ClientId
        {
            get { return _clientId; }

            set { base.SetContainerProperty(ref _clientId, value); }
        }

        /// <summary>
        /// ClientSecret
        /// </summary>
        public string ClientSecret
        {
            get { return _clientSecret; }
            set { base.SetContainerProperty(ref _clientSecret, value); }
        }

        /// <summary>
        /// 预授权码
        /// </summary>
        public string PreAuthCode
        {
            get { return _preCode; }
            set { base.SetContainerProperty(ref _preCode, value); }
        }

        /// <summary>
        /// 转向Uri
        /// </summary>
        public string RedirectUri
        {
            get { return _redirectUri; }
            set { base.SetContainerProperty(ref _redirectUri, value); }
        }

        /// <summary>
        /// AccessToken过期时间
        /// </summary>
        public DateTime AccessTokenExpireTime
        {
            get { return _accessTokenExpireTime; }
            set { base.SetContainerProperty(ref _accessTokenExpireTime, value); }
        }

        /// <summary>
        /// AccessToken
        /// </summary>
        public AccessTokenResult AccessTokenResult
        {
            get { return _accessTokenResult; }
            set { base.SetContainerProperty(ref _accessTokenResult, value); }
        }

    }

    public class AccessTokenContainer : BaseContainer<AccessTokenBag>
    {
        const string LockResourceName = "Product.AccessTokenContainer";

        /// <summary>
        /// 注册应用凭证信息，此操作只是注册，不会马上获取Token，并将清空之前的Token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="name"></param>
        public static void Register(string clientId, string clientSecret, string preAuthCode, string redirectUri, string name = null)
        {
            //如果此clinetId 未注册,则进行注册 
            if (!CheckRegistered(clientId))
            {
                //记录注册信息，RegisterFunc委托内的过程会在缓存丢失之后自动重试
                RegisterFunc = () =>
                {
                    using (FlushCache.CreateInstance())
                    {
                        var bag = new AccessTokenBag()
                        {
                            Key = clientId,
                            Name = name,
                            ClientId = clientId,
                            ClientSecret = clientSecret,
                            PreAuthCode = preAuthCode,
                            RedirectUri = redirectUri,
                            AccessTokenExpireTime = DateTime.MinValue,
                            AccessTokenResult = new AccessTokenResult()
                        };
                        Update(clientId, bag);
                        return bag;
                    }
                };

                RegisterFunc();

                //OAuthAccessTokenContainer进行自动注册
                //OAuthAccessTokenContainer.Register(clientId, clientSecret, name);
            }
        }

        /// <summary>
        /// 注册应用凭证信息，此操作为注册完整信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="expiresIn"></param>
        /// <param name="expiryTime"></param>
        /// <param name="refreshToken"></param>
        /// <param name="redirectUri"></param>
        /// <param name="appName"></param>
        public static void Register(string clientId, string clientSecret, string accessToken, int expiresIn, int expiryTime, string refreshToken, string redirectUri, string appName = null)
        {
            if (!CheckRegistered(clientId))
            {
                RegisterFunc = () =>
                {
                    using (FlushCache.CreateInstance())
                    {
                        var bag = new AccessTokenBag()
                        {
                            Key = clientId,
                            AppName = appName,
                            ClientId = clientId,
                            ClientSecret = clientSecret,
                            RedirectUri = redirectUri,
                            AccessTokenExpireTime = ApiUtility.GetExpireTime(expiresIn),
                            AccessTokenResult = new AccessTokenResult()
                        };

                        bag.AccessTokenResult.data.access_token = accessToken;
                        bag.AccessTokenResult.data.refresh_token = refreshToken;
                        bag.AccessTokenResult.data.expires_in = expiresIn;
                        bag.AccessTokenResult.data.expiry_time = expiryTime;

                        Update(clientId, bag);
                        return bag;
                    }
                };

                RegisterFunc();
            }
        }

        #region 同步方法

        #region AccessToken

        /// <summary>
        /// 使用完整的应用凭证获取Token，如果不存在将自动注册
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static string TryGetAccessToken(string clientId, string clientSecret, string preAuthCode, string redirectUri, bool getNewToken = false)
        {
            if (!CheckRegistered(clientId) || getNewToken)
            {
                Register(clientId, clientSecret, preAuthCode, redirectUri);
            }
            return GetAccessToken(clientId, getNewToken);
        }

        /// <summary>
        /// 使用完整的应用凭证获取Token，如果不存在将自动注册
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="getNewToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static string TryGetAccesToken(string clientId, string clientSecret, string preAuthCode, string redirectUri, bool getNewToken = true, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId) || getNewToken)
            {
                Register(clientId, clientSecret, preAuthCode, redirectUri);
            }
            return GetAccessToken(clientId, getNewToken, sessionType);
        }

        /// <summary>
        /// 获取可用Token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static string GetAccessToken(string clientId, bool getNewToken = false)
        {
            return GetAccessTokenResult(clientId, getNewToken).data.access_token;
        }

        /// <summary>
        /// 获取可用Token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static string GetAccessToken(string clientId, bool getNewToken = false, SessionType sessionType = SessionType.Prod)
        {
            return GetAccessTokenResult(clientId, getNewToken, sessionType).data.access_token;
        }

        /// <summary>
        /// 获取可用AccessTokenResult对象
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static AccessTokenResult GetAccessTokenResult(string clientId, bool getNewToken = false, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId))
            {
                throw new UnRegisterClientIdException(clientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", clientId));
            }

            var accessTokenBag = TryGetItem(clientId);

            using (Cache.BeginCacheLock(LockResourceName, clientId))//同步锁
            {
                if (getNewToken || accessTokenBag.AccessTokenExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    //accessTokenBag.AccessTokenResult = CommonApi.GetToken(accessTokenBag.clientId, accessTokenBag.clientSecret);
                    //accessTokenBag.AccessTokenExpireTime = ApiUtility.GetExpireTime(accessTokenBag.AccessTokenResult.expires_in);

                    accessTokenBag.AccessTokenResult = CommonApi.GetAccessToken(accessTokenBag.ClientId, accessTokenBag.ClientSecret, accessTokenBag.PreAuthCode, accessTokenBag.RedirectUri, sessionType);
                    accessTokenBag.AccessTokenExpireTime = ApiUtility.GetExpireTime(accessTokenBag.AccessTokenResult.data.expires_in);

                }
            }
            return accessTokenBag.AccessTokenResult;
        }

        /// <summary>
        /// 刷新 AccessToken
        /// </summary>
        /// <param name="client"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static AccessTokenResult RefreshAccessTokenResult(string clientId, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId))
            {
                throw new UnRegisterClientIdException(clientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", clientId));
            }

            var accessTokenBag = TryGetItem(clientId);

            using (Cache.BeginCacheLock(LockResourceName, clientId))//同步锁
            {

                accessTokenBag.AccessTokenResult = CommonApi.RefreshAccessToken(accessTokenBag.ClientId, accessTokenBag.ClientSecret, accessTokenBag.AccessTokenResult.data.refresh_token, sessionType);
                accessTokenBag.AccessTokenExpireTime = ApiUtility.GetExpireTime(accessTokenBag.AccessTokenResult.data.expires_in);
            }
            return accessTokenBag.AccessTokenResult;
        }

        #endregion

        #endregion

        #region 异步方法

        #region AccessToken

        /// <summary>
        /// 【异步方法】使用完整的应用凭证获取Token，如果不存在将自动注册
        /// 
        /// 主入口函数
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="getNewToken"></param>
        /// <returns></returns>
        public static async Task<string> TryGetAccessTokenAsync(string clientId, string clientSecret, string preAuthCode, string redirectUri, bool getNewToken = false)
        {
            if (!CheckRegistered(clientId) || getNewToken)
            {
                Register(clientId, clientSecret, preAuthCode, redirectUri);
            }
            return await GetAccessTokenAsync(clientId, getNewToken);
        }

        /// <summary>
        /// 【异步方法】使用完整的应用凭证获取Token，如果不存在将自动注册
        /// 
        /// 主入口函数
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="getNewToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<string> TryGetAccessTokenAsync(string clientId, string clientSecret, string preAuthCode, string redirectUri, bool getNewToken = false, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId) || getNewToken)
            {
                Register(clientId, clientSecret, preAuthCode, redirectUri);
            }
            return await GetAccessTokenAsync(clientId, getNewToken, sessionType);
        }

        /// <summary>
        /// 【异步方法】获取可用Token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static async Task<string> GetAccessTokenAsync(string clientId, bool getNewToken = false)
        {
            var result = await GetAccessTokenResultAsync(clientId, getNewToken);
            return result.data.access_token;
        }

        /// <summary>
        /// 【异步方法】获取可用Token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<string> GetAccessTokenAsync(string clientId, bool getNewToken = false, SessionType sessionType = SessionType.Prod)
        {
            var result = await GetAccessTokenResultAsync(clientId, getNewToken, sessionType);
            return result.data.access_token;
        }

        /// <summary>
        /// 获取可用AccessTokenResult对象
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="getNewToken">是否强制重新获取新的Token</param>
        /// <returns></returns>
        public static async Task<AccessTokenResult> GetAccessTokenResultAsync(string clientId, bool getNewToken = false, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId))
            {
                throw new UnRegisterClientIdException(clientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", clientId));
            }

            var accessTokenBag = TryGetItem(clientId);

            using (Cache.BeginCacheLock(LockResourceName, clientId))//同步锁
            {
                if (getNewToken || accessTokenBag.AccessTokenExpireTime <= DateTime.Now)
                {
                    //已过期，重新获取
                    var accessTokenResult = await CommonApi.GetAccessTokenAsync(accessTokenBag.ClientId, accessTokenBag.ClientSecret, accessTokenBag.PreAuthCode, accessTokenBag.RedirectUri, sessionType);
                    accessTokenBag.AccessTokenResult = accessTokenResult;
                    accessTokenBag.AccessTokenExpireTime = ApiUtility.GetExpireTime(accessTokenBag.AccessTokenResult.data.expires_in);
                }
            }
            return accessTokenBag.AccessTokenResult;
        }

        /// <summary>
        /// 刷新AccessToken
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<AccessTokenResult> RefreshAccessTokenResultAsync(string clientId, SessionType sessionType = SessionType.Prod)
        {
            if (!CheckRegistered(clientId))
            {
                throw new UnRegisterClientIdException(clientId, string.Format("此clientId（{0}）尚未注册，请先使用AccessTokenContainer.Register完成注册（全局执行一次即可）！", clientId));
            }

            var accessTokenBag = TryGetItem(clientId);

            using (Cache.BeginCacheLock(LockResourceName, clientId))//同步锁
            {

                var accessTokenResult = await CommonApi.RefreshAccessTokenAsync(accessTokenBag.ClientId, accessTokenBag.ClientSecret, accessTokenBag.AccessTokenResult.data.refresh_token, sessionType);
                accessTokenBag.AccessTokenResult = accessTokenResult;
                accessTokenBag.AccessTokenExpireTime = ApiUtility.GetExpireTime(accessTokenBag.AccessTokenResult.data.expires_in);

            }
            return accessTokenBag.AccessTokenResult;
        }

        #endregion

        #endregion
    }

}
