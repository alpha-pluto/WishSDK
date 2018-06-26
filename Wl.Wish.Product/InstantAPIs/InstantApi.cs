/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：InstantApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关商品的操作)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.HttpUtility;
using Wl.Wish.Product.CommonAPIs;

namespace Wl.Wish.Product.InstantAPIs
{
    public partial class InstantApi
    {
        #region 同步请求

        /// <summary>
        /// 获取所有商品
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#list-all-product
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="posStart">起始位置，数字</param>
        /// <param name="numLimit">要获取的商品数量，数字 </param>
        /// <param name="sinceDate">自此时间之后</param>
        /// <param name="showRejected">为true 则wish审核未通过的商品也一起列出</param>
        /// <param name="sessionType">prod 正式环境 ，sandbox 沙盒环境 </param>
        /// <returns></returns>
        public static ProductList ProductAllRetrieve(string clientId, string accessToken, int? posStart = null, int? numLimit = null, string sinceDate = null, bool? showRejected = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/multi-get",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    ///optional An offset into the list of returned items.
                    ///Use 0 to start at the beginning. The API will return the requested number of items starting at this offset. Default to 0 if not supplied
                    start = posStart,

                    ///optional A limit on the number of products that can be returned. Limit can range from 1 to 250 items and the default is 50
                    limit = numLimit,

                    ///optional A date string in the format YYYY-MM-DD. 
                    ///If a date is provided, only products updated since the given date will be fetched. Default is to fetch all.
                    since = sinceDate,

                    ///optional If specified to 'true', this API will return all products including those inappropriate products that were rejected during review.
                    show_rejected = showRejected

                };
                var result = CommonJsonSend.Send<ProductList>(token, url, data, CommonJsonSendType.GET);
                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 移除商品的图片，只保留主图（通过 product_id或 parent_sku ）
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#product-remove-extra-images
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductExtraPhotoRemove(string clientId, string accessToken, string productId, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/remove-extra-images",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = productId,
                    parent_sku = parentSku
                };

                var result = CommonJsonSend.Send<ProductResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更改商品的运费(统一)
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#edit-product-shipping
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceSingle"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductShippingPriceEditSingle(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceSingle productShippingPriceSingle, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/update-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<ProductResultBase>(token, url, productShippingPriceSingle, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更改商品的运费(个别，多选)
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#update-multi-shipping
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceMultiple"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductResultBase ProductShippingPriceEditMultiple(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceMultiple productShippingPriceMultiple, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/update-multi-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<ProductResultBase>(token, url, productShippingPriceMultiple, CommonJsonSendType.POST);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得某商品到某国家的运费
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#get-shipping
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceSingle"> id,parent_sku 必写其一;country 两位国家代码 </param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductShippingPriceSingle ProductShippingPriceRetrieveSingle(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceSingle productShippingPriceSingle, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/get-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<ProductShippingPriceSingle>(token, url, productShippingPriceSingle, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得某商品的所有运费
        /// product_id 和 parent_sku 必填其一
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#get-product-all-shipping
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId">商品 id</param>
        /// <param name="parentSku">parent_sku</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductShippingPriceMultiple ProductShippingPriceRetrieveMultiple(string clientId, string accessToken, string productId = null, string parentSku = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {

                var url =
                    string.Format("{0}/api/v2/product/get-all-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = productId,
                    parent_sku = parentSku
                };

                var result = CommonJsonSend.Send<ProductShippingPriceMultiple>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得多个商品的所有运费设置 
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-products-shipping
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productIds"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductShippingPriceMultipleOfMany ProductShippingPriceRetrieveMultipleOfMany(string clientId, string accessToken, string productIds = null, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-products-shipping",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    ids = productIds
                };

                var result = CommonJsonSend.Send<ProductShippingPriceMultipleOfMany>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得运费设置
        /// 
        /// 原始文档
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-shipping-setting
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static ProductShippingSettings ProductShippingSettingsRetrieve(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-shipping-setting",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);


                var result = CommonJsonSend.Send<ProductShippingSettings>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }


        #endregion

        #region 异步请求

        /// <summary>
        /// 获取所有商品(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="posStart">起始位置，数字</param>
        /// <param name="numLimit">要获取的商品数量，数字 </param>
        /// <param name="sinceDate">自此时间之后</param>
        /// <param name="showRejected">为true 则wish审核未通过的商品也一起列出</param>
        /// <param name="sessionType">prod 正式环境 ，sandbox 沙盒环境 </param>
        /// <returns></returns>
        public static async Task<ProductList> ProductAllRetrieveAsync(string clientId, string accessToken, int? posStart = null, int? numLimit = null, string sinceDate = null, bool? showRejected = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/multi-get",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    ///optional An offset into the list of returned items.
                    ///Use 0 to start at the beginning. The API will return the requested number of items starting at this offset. Default to 0 if not supplied
                    start = posStart,

                    ///optional A limit on the number of products that can be returned. Limit can range from 1 to 250 items and the default is 50
                    limit = numLimit,

                    ///optional A date string in the format YYYY-MM-DD. 
                    ///If a date is provided, only products updated since the given date will be fetched. Default is to fetch all.
                    since = sinceDate,

                    ///optional If specified to 'true', this API will return all products including those inappropriate products that were rejected during review.
                    show_rejected = showRejected

                };

                var result = CommonJsonSend.SendAsync<ProductList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 移除商品的图片，只保留主图（异步，通过 product_id或 parent_sku ）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductExtraPhotoRemoveAsync(string clientId, string accessToken, string productId, string parentSku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/remove-extra-images",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);
                var data = new
                {
                    id = productId,
                    parent_sku = parentSku
                };

                var result = CommonJsonSend.SendAsync<ProductResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更改商品的运费(统一,异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceSingle"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductShippingPriceEditSingleAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceSingle productShippingPriceSingle, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/update-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<ProductResultBase>(token, url, productShippingPriceSingle, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更改商品的运费(异步，个别，多选)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceMultiple"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductResultBase> ProductShippingPriceEditMultipleAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceMultiple productShippingPriceMultiple, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/update-multi-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<ProductResultBase>(token, url, productShippingPriceMultiple, CommonJsonSendType.POST);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得某商品到某国家的运费(异步)
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productShippingPriceSingle"> id,parent_sku 必写其一;country 两位国家代码 </param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductShippingPriceSingle> ProductShippingPriceRetrieveSingleAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.ProductShippingPriceSingle productShippingPriceSingle, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/get-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<ProductShippingPriceSingle>(token, url, productShippingPriceSingle, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得某商品的所有运费(异步)
        /// product_id 和 parent_sku 必填其一
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productId"></param>
        /// <param name="parentSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductShippingPriceMultiple> ProductShippingPriceRetrieveMultipleAsync(string clientId, string accessToken, string productId = null, string parentSku = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/product/get-all-shipping",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    id = productId,
                    parent_sku = parentSku
                };

                var result = CommonJsonSend.SendAsync<ProductShippingPriceMultiple>(token, url, data, CommonJsonSendType.GET);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得多个商品的所有运费设置(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="productIds"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductShippingPriceMultipleOfMany> ProductShippingPriceRetrieveMultipleOfManyAsync(string clientId, string accessToken, string productIds = null, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-products-shipping",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    ids = productIds
                };

                var result = CommonJsonSend.SendAsync<ProductShippingPriceMultipleOfMany>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得运费设置
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<ProductShippingSettings> ProductShippingSettingsRetrieveAsync(string clientId, string accessToken, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                       string.Format("{0}/api/v2/product/get-shipping-setting",
                                   sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);


                var result = CommonJsonSend.SendAsync<ProductShippingSettings>(token, url, null, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }


        #endregion
    }
}
