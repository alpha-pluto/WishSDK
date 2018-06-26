/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：CommonJsonSend.cs
    文件功能描述：向需要AccessToken的API发送消息的公共方法

----------------------------------------------------------------*/

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;
using Wl.Wish.Exceptions;
using Wl.Wish.Helpers;
using Wl.Wish.HttpUtility;

namespace Wl.Wish.Product.CommonAPIs
{
    public static class CommonJsonSend
    {
        #region 同步请求

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static WishJsonResult Send(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            WishJsonResult result = null;

            try
            {
                result = Wl.Wish.CommonAPIs.CommonJsonSend.Send(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static T Send<T>(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            T result = default(T);
            try
            {
                result = Wl.Wish.CommonAPIs.CommonJsonSend.Send<T>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        #endregion

        #region 异步请求

        /// <summary>
        /// 发送数据，取得并解析数据（最基本的数据，异步）
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<WishJsonResult> SendAsync(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT)
        {
            return await Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<WishJsonResult>(accessToken, urlFormat, data, sendType, timeOut);
        }

        public static async Task<WishJsonResult> SendAsync(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            return await Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<WishJsonResult>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

        /// <summary>
        /// 发送数据，取得并解析数据（泛型  异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accessToken"></param>
        /// <param name="urlFormat"></param>
        /// <param name="data"></param>
        /// <param name="sendType"></param>
        /// <param name="timeOut"></param>
        /// <param name="checkValidationResult"></param>
        /// <param name="jsonSetting"></param>
        /// <returns></returns>
        public static async Task<T> SendAsync<T>(string accessToken, string urlFormat, object data, CommonJsonSendType sendType = CommonJsonSendType.POST, int timeOut = Config.TIME_OUT, bool checkValidationResult = false, JsonSetting jsonSetting = null)
        {
            return await Wl.Wish.CommonAPIs.CommonJsonSend.SendAsync<T>(accessToken, urlFormat, data, sendType, timeOut, checkValidationResult, jsonSetting);
        }

        #endregion
    }
}
