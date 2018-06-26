/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OAuthAPI.cs
    文件功能描述：获得访问令牌
 
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Open;
using Wl.Wish.HttpUtility;
using Wl.Wish.CommonAPIs;

namespace Wl.Wish.Open.OAuthAPIs
{
    public static class OAuthApi
    {
        #region 同步请求

        /*此接口不提供异步方法*/
        /// <summary>
        /// 获取验证地址
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="redirectUrl">Your app's redirect uri that you specified when you created the app</param>
        /// <param name="grantType"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static string GetAuthorizeUrl(string clientId, string redirectUrl, string grantType = "authorization_code", SessionType sessionType = SessionType.Prod)
        {

            var url =
                string.Format("{0}/oauth/authorize?client_id={1}",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot, clientId.AsUrlData());

            /* 这一步发送之后，客户会得到授权页面，无论同意或拒绝，都会返回redirectUrl页面。
             * 如果用户同意授权，页面将跳转至 redirect_uri?code={authorization_code}。这里的code用于换取access_token 
             * 若用户禁止授权，则重定向后不会带上code参数 
             */
            return url;
        }

        /// <summary>
        /// 获取AccessToken
        /// 
        /// 范例
        /// https://www.merchant.wish.com/documentation/oauth
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="grantType">authorization_code</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OAuthAccessTokenResult GetAccessToken(string clientId, string clientSecret, string preAuthCode, string redirectUrl, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/oauth/access_token",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                code = preAuthCode,//    The authorization code you received
                grant_type = "authorization_code",
                redirect_uri = redirectUrl
            };
            return CommonJsonSend.Send<OAuthAccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Access Tokens
        /// 
        /// 范例 
        /// https://www.merchant.wish.com/documentation/oauth
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OAuthAccessTokenResult RefreshAccessToken(string clientId, string clientSecret, string refreshToken, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/oauth/refresh_token",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken,//    The authorization code you received
                grant_type = "refresh_token"
            };
            return CommonJsonSend.Send<OAuthAccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 测试token
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#introduction
        /// 
        /// Test Authentication
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static OAuthAccessTokenTestResult TestAccessToken(string accessToken, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/auth_test",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                access_token = accessToken
            };
            return CommonJsonSend.Send<OAuthAccessTokenTestResult>(null, url, data, CommonJsonSendType.POST);
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 获取AccessToken ( 异步 )
        /// 
        /// 范例
        /// https://www.merchant.wish.com/documentation/oauth
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="grantType">authorization_code</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> GetAccessTokenAsync(string clientId, string clientSecret, string preAuthCode, string redirectUrl, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/oauth/access_token",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                code = preAuthCode,//    The authorization code you received
                grant_type = "authorization_code",
                redirect_uri = redirectUrl
            };

            return await CommonJsonSend.SendAsync<OAuthAccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Access Tokens (异步)
        /// 
        /// 范例 
        /// https://www.merchant.wish.com/documentation/oauth
        /// 
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenResult> RefreshAccessTokenAsync(string clientId, string clientSecret, string refreshToken, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/oauth/refresh_token",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                refresh_token = refreshToken,//    The authorization code you received
                grant_type = "refresh_token"
            };
            return await CommonJsonSend.SendAsync<OAuthAccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 测试token (测试)
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#introduction
        /// 
        /// Test Authentication
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<OAuthAccessTokenTestResult> TestAccessTokenAsync(string accessToken, SessionType sessionType = SessionType.Prod)
        {
            var url =
                string.Format("{0}/api/v2/auth_test",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

            var data = new
            {
                access_token = accessToken
            };
            return await CommonJsonSend.SendAsync<OAuthAccessTokenTestResult>(null, url, data, CommonJsonSendType.POST);
        }

        #endregion
    }
}
