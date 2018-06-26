/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：VariantApi.cs
    文件功能描述：通用接口(用于和Wish 服务器通讯，有关商品规格的操作)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Product.Entities;
using Wl.Wish.HttpUtility;
using Wl.Wish.Product.CommonAPIs;

namespace Wl.Wish.Product.VariantAPIs
{
    public partial class VariantApi
    {
        #region 同步请求

        /// <summary>
        /// 添加一个商品规格
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#create-product-variation
        /// 
        /// variant参数 =>
        /// parent_sku,
        /// sku,
        /// inventory,
        /// price,
        /// shipping,
        /// color 可空,
        /// size 可空,
        /// msrp 可空,
        /// shipping_time 可空,
        /// main_image 可空
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="variant"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResult ProductVariantCreate(string clientId, string accessToken, Wl.Wish.Entities.Request.Variant variant, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/variant/add",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<VariantResult>(token, url, variant, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获得商品规格数据 
        /// 
        /// 原始文档 
        /// 
        /// https://www.merchant.wish.com/documentation/api/v2#get-product-variation
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResult ProductVariantRetrieve(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                    string.Format("{0}/api/v2/variant",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.Send<VariantResult>(token, url, data, CommonJsonSendType.GET);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改商品规格
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#update-product-variation
        /// 
        /// variant参数 =>
        /// sku,
        /// inventory 可空,
        /// price 可空,
        /// shipping 可空,
        /// enabled 可空,
        /// color 可空,
        /// size 可空,
        /// msrp 可空,
        /// shipping_time 可空,
        /// main_image 可空
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="variant"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResultBase ProductVariantUpdate(string clientId, string accessToken, Wl.Wish.Entities.Request.Variant variant, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/update",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.Send<VariantResultBase>(token, url, variant, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 变更商品规格的SKU
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#change-product-variation-sku
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="previousSku"></param>
        /// <param name="newSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResultBase ProductVariantSkuChange(string clientId, string accessToken, string previousSku, string newSku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/change-sku",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = previousSku,
                    new_sku = newSku
                };

                var result = CommonJsonSend.Send<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 启用一个商品规格
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#enable-product-variation
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResultBase ProductVariantEnable(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/enable",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.Send<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 禁用一个商品规格
        /// 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#disable-product-variation
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResultBase ProductVariantDisable(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/disable",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.Send<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更新商品规格的库存数量 
        /// 原始文档 
        /// https://www.merchant.wish.com/documentation/api/v2#update-product-variation-inventory
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="inventory"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantResultBase ProductVariantInventoryUpdate(string clientId, string accessToken, string sku, int inventory, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/update-inventory",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku,
                    inventory = inventory
                };

                var result = CommonJsonSend.Send<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取所有商品规格数据 
        /// 
        /// 原始文档
        /// https://www.merchant.wish.com/documentation/api/v2#list-all-product-variation
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start">起始</param>
        /// <param name="limit">限制</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static VariantList ProductVariantListAll(string clientId, string accessToken, int start = 0, int limit = 50, SessionType sessionType = SessionType.Prod)
        {
            return ApiHandlerWrapper.TryCommonApi(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/multi-get",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit
                };

                var result = CommonJsonSend.Send<VariantList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 添加一个商品规格(异步)
        /// variant参数=>
        /// parent_sku,
        /// sku,
        /// inventory,
        /// price,
        /// shipping,
        /// color 可空,
        /// size 可空,
        /// msrp 可空,
        /// shipping_time 可空,
        /// main_image 可空
        /// </summary>
        /// <param name="acccesToken"></param>
        /// <param name="variant"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResult> ProductVariantCreateAsync(string clientId, string acccesToken, Wl.Wish.Entities.Request.Variant variant, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/variant/add",

                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<VariantResult>(token, url, variant, CommonJsonSendType.POST);

                return result;

            }, clientId, acccesToken, sessionType);

        }

        /// <summary>
        /// 获得商品规格数据(异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResult> ProductVariantRetrieveAsync(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                    string.Format("{0}/api/v2/variant",
                                sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.SendAsync<VariantResult>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 修改商品规格 (异步)
        /// variant参数 =>
        /// sku,
        /// inventory 可空,
        /// price 可空,
        /// shipping 可空,
        /// enabled 可空,
        /// color 可空,
        /// size 可空,
        /// msrp 可空,
        /// shipping_time 可空,
        /// main_image 可空
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="variant"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResult> ProductVariantUpdateAsync(string clientId, string accessToken, Wl.Wish.Entities.Request.Variant variant, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/update",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var result = CommonJsonSend.SendAsync<VariantResult>(token, url, variant, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 变更商品规格的SKU (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="previousSku"></param>
        /// <param name="newSku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResultBase> ProductVariantSkuChangeAsync(string clientId, string accessToken, string previousSku, string newSku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/change-sku",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = previousSku,
                    new_sku = newSku
                };

                var result = CommonJsonSend.SendAsync<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 启用一个商品规格 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResultBase> ProductVariantEnableAsync(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/enable",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.SendAsync<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 禁用一个商品规格 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResultBase> ProductVariantDisableAsync(string clientId, string accessToken, string sku, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/disable",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku
                };

                var result = CommonJsonSend.SendAsync<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;

            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 更新商品规格的库存数量 (异步)
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sku"></param>
        /// <param name="inventory"></param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantResultBase> ProductVariantInventoryUpdateAsync(string clientId, string accessToken, string sku, int inventory, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/update-inventory",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    sku = sku,
                    inventory = inventory
                };

                var result = CommonJsonSend.SendAsync<VariantResultBase>(token, url, data, CommonJsonSendType.POST);

                return result;
            }, clientId, accessToken, sessionType);
        }

        /// <summary>
        /// 获取所有商品规格数据 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="start">起始</param>
        /// <param name="limit">限制</param>
        /// <param name="sessionType"></param>
        /// <returns></returns>
        public static async Task<VariantList> ProductVariantListAllAsync(string clientId, string accessToken, int start = 0, int limit = 50, SessionType sessionType = SessionType.Prod)
        {
            return await ApiHandlerWrapper.TryCommonApiAsync(token =>
            {
                var url =
                   string.Format("{0}/api/v2/variant/multi-get",
                               sessionType == SessionType.Sandbox ? Wl.Wish.Config.RequestUriRootSandbox : Wl.Wish.Config.RequestUriRoot);

                var data = new
                {
                    start = start,
                    limit = limit
                };

                var result = CommonJsonSend.SendAsync<VariantList>(token, url, data, CommonJsonSendType.GET);

                return result;

            }, clientId, accessToken, sessionType);
        }

        #endregion
    }
}
