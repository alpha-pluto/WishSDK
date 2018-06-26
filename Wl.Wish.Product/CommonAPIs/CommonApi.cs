/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：CommonApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，一般不涉及自有网站服务器的通讯)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.HttpUtility;


namespace Wl.Wish.Product.CommonAPIs
{
    public partial class CommonApi
    {
        #region 同步

        /// <summary>
        /// 获取access_token
        /// 
        /// https://www.merchant.wish.com/documentation/oauth
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static AccessTokenResult GetAccessToken(string clientId, string clientSecret, string preAuthCode, string redirectUri, SessionType sessionType = SessionType.Prod)
        {
            //注意：此方法不能再使用ApiHandlerWapper.TryCommonApi()，否则会循环
            var url =
            string.Format("{0}/api/v2/oauth/access_token",
                            sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
            var data = new
            {
                client_id = clientId,//   Your app's client ID
                client_secret = clientSecret,//   Your app's client secret
                code = preAuthCode,//    The authorization code you received
                grant_type = "authorization_code",
                redirect_uri = redirectUri
            };

            return Wl.Wish.CommonAPIs.CommonJsonSend.Send<AccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// Obtaining New Access Tokens
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/oauth
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static AccessTokenResult RefreshAccessToken(string clientId, string clientSecret, string refreshToken, SessionType sessionType = SessionType.Prod)
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
            return Wl.Wish.CommonAPIs.CommonJsonSend.Send<AccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 创建商品
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#create-product
        /// 
        /// 商品参数
        /// name 
        /// description
        /// tags
        /// sku
        /// inventory
        /// price
        /// shipping
        /// main_image
        /// color optional
        /// size optional
        /// msrp optional
        /// shipping_time optional
        /// parent_sku optional
        /// brand optional
        /// landing_page_url optional
        /// upc optional
        /// extra_images optional 
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="product"></param>
        /// <param name="sessionType">Prod 正式环境，Sandbox 沙盒环境</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static ProductResult ProductCreate(string clientId, string accessToken, Wl.Wish.Entities.Request.Product product, SessionType sessionType = SessionType.Prod, int timeOut = Config.TIME_OUT)
        {

            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/add",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<ProductResult>(token, url, product, CommonJsonSendType.POST, timeOut);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 按product_id来获取产品 
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-product
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResult ProductRetrieveViaId(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product?id={1}&access_token={2}",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot,
                                productId,
                                token);

                var result = CommonJsonSend.Send<ProductResult>(null, url, null, CommonJsonSendType.GET);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 通过 parent_sku 获取商品信息
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-product
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResult ProductRetrieveViaParentSku(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product?parent_sku={1}&access_token={2}",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot,
                                parentSku,
                                token);

                var result = CommonJsonSend.Send<ProductResult>(null, url, null, CommonJsonSendType.GET);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 通过 product_id 或 parent_sku 更新 商品
        /// 
        /// 商品参数
        /// id
        /// parent_sku
        /// name optional
        /// description optional
        /// tags optional
        /// brand optional
        /// landing_page_url optional
        /// upc optional
        /// extra_images optional
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#update-product
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="product"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductUpdate(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductToUpdate product, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/update",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<ProductResultBase>(token, url, product, CommonJsonSendType.POST);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品上架 (通过 product_id)
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#enable-product
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductEnableViaId(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/enable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    id = productId
                };
                var result = CommonJsonSend.Send<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品上架(通过 parent_sku)
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#enable-product
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductEnbaleViaParentSku(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/enable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    parent_sku = parentSku
                };
                var result = CommonJsonSend.Send<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品下架 (通过 product_id,parent_sku)
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#disable-product
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductDisableViaId(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/disable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    id = productId
                };
                var result = CommonJsonSend.Send<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品下架(通过 parent_sku)
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#disable-product
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductDisableViaParentSku(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/disable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    parent_sku = parentSku
                };
                var result = CommonJsonSend.Send<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步

        /// <summary>
        /// 获取access_token,异步
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="preAuthCode"></param>
        /// <param name="redirectUri"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<AccessTokenResult> GetAccessTokenAsync(string clientId, string clientSecret, string preAuthCode, string redirectUri, SessionType sessionType = SessionType.Prod)
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
                redirect_uri = redirectUri
            };

            return await Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<AccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 刷新access_token,异步
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<AccessTokenResult> RefreshAccessTokenAsync(string clientId, string clientSecret, string refreshToken, SessionType sessionType = SessionType.Prod)
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
            return await Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<AccessTokenResult>(null, url, data, CommonJsonSendType.POST);
        }

        /// <summary>
        /// 创建商品,异步
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="product"></param>
        /// <param name="sessionType"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<ProductResult> ProductCreateAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.Product product, SessionType sessionType = SessionType.Prod, int timeOut = Config.TIME_OUT)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/add",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResult>(token, url, product, CommonJsonSendType.POST, timeOut);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 通过 product_id 获取商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResult> ProductRetrieveViaIdAsync(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product?id={1}&access_token={2}",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot,
                                productId,
                                token);

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResult>(null, url, null, CommonJsonSendType.GET);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 通过 parent_sku 获得商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResult> ProductRetrieveViaSkuAsync(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product?parent_sku={1}&access_token={2}",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot,
                                parentSku,
                                token);

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResult>(null, url, null, CommonJsonSendType.GET);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 通过 product_id 或 parent_sku 更新商品
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="product"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductUpdateAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductToUpdate product, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/update",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResultBase>(token, url, product, CommonJsonSendType.POST);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品上架（异步，通过 product_id）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductEnableViaIdAsync(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/enable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    id = productId
                };
                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品上架(异步，通过 parent_sku)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductEnableViaParentSkuAsync(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/enable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    parent_sku = parentSku
                };
                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResultBase>(token, url, data, CommonJsonSendType.POST);
                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品下架（异步，通过 product_id）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductDisableViaIdAsync(string clientId, string accessToken, string productId, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/disable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    id = productId
                };

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 商品下架(异步，通过 parent_sku)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductDisableViaParentSkuAsync(string clientId, string accessToken, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/disable",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    parent_sku = parentSku
                };

                var result = Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<ProductResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

    }
}
