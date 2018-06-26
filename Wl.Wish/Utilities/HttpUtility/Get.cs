/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Get.cs
    文件功能描述：Get

----------------------------------------------------------------*/

using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Wl.Wish.Entities;
using Wl.Wish.Exceptions;

namespace Wl.Wish.HttpUtility
{
    /// <summary>
    /// Get请求处理
    /// </summary>
    public static class Get
    {
        #region 同步方法

        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = RequestUtility.HttpGet(url, encoding);

            WishTrace.SendApiLog(url, returnText);

            JavaScriptSerializer js = new JavaScriptSerializer();
            if (maxJsonLength.HasValue)
            {
                js.MaxJsonLength = maxJsonLength.Value;
            }

            //if (returnText.Contains("errcode"))
            //当错误代码不为0时，发生错误
            if (System.Text.RegularExpressions.Regex.IsMatch(returnText, @"(?isx)[\x22\x27]code[\x22\x27][\s\r\n]*\:[\s\r\n]*[1-9]+"))
            {
                //可能发生错误
                WishJsonResult errorResult = js.Deserialize<WishJsonResult>(returnText);
                if (errorResult.code != (int)ReturnCode.Success)
                {
                    //发生错误
                    throw new ErrorJsonResultException(
                        string.Format("请求发生错误！错误代码：{0}，说明：{1}",
                                        (int)errorResult.code, errorResult.message), null, errorResult, url);
                }
            }

            T result = js.Deserialize<T>(returnText);

            return result;
        }

        /// <summary>
        /// 从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public static void Download(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            foreach (var b in data)
            {
                stream.WriteByte(b);
            }
        }

        /// <summary>
        /// 从Url下载，并保存到指定目录
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static string Download(string url, string dir)
        {
            Directory.CreateDirectory(dir);
            System.Net.Http.HttpClient httpClient = new HttpClient();
            using (var responseMessage = httpClient.GetAsync(url).Result)
            {
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var fullName = Path.Combine(dir, responseMessage.Content.Headers.ContentDisposition.FileName.Trim('"'));
                    using (var fs = File.Open(fullName, FileMode.Create))
                    {
                        using (var responseStream = responseMessage.Content.ReadAsStreamAsync().Result)
                        {
                            responseStream.CopyTo(fs);
                            return fullName;
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region 异步方法

        /// <summary>
        /// 【异步方法】异步GetJson
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ErrorJsonResultException"></exception>
        public static async Task<T> GetJsonAsync<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = await RequestUtility.HttpGetAsync(url, encoding);

            JavaScriptSerializer js = new JavaScriptSerializer();
            if (maxJsonLength.HasValue)
            {
                js.MaxJsonLength = maxJsonLength.Value;
            }

            //if (returnText.Contains("errcode"))
            //当错误代码不为0时，发生错误
            if (System.Text.RegularExpressions.Regex.IsMatch(returnText, @"(?isx)[\x22\x27]code[\x22\x27][\s\r\n]*\:[\s\r\n]*[1-9]+"))
            {
                //可能发生错误
                WishJsonResult errorResult = js.Deserialize<WishJsonResult>(returnText);
                if (errorResult.code != (int)ReturnCode.Success)
                {
                    //发生错误
                    throw new ErrorJsonResultException(
                        string.Format("请求发生错误！错误代码：{0}，说明：{1}",
                                        (int)errorResult.code, errorResult.message), null, errorResult, url);
                }
            }

            T result = js.Deserialize<T>(returnText);

            return result;
        }

        /// <summary>
        /// 【异步方法】异步从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task DownloadAsync(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            WebClient wc = new WebClient();
            var data = await wc.DownloadDataTaskAsync(url);
            await stream.WriteAsync(data, 0, data.Length);
            //foreach (var b in data)
            //{
            //    stream.WriteAsync(b);
            //}
        }

        /// <summary>
        /// 【异步方法】从Url下载，并保存到指定目录
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static async Task<string> DownloadAsync(string url, string dir)
        {
            Directory.CreateDirectory(dir);
            System.Net.Http.HttpClient httpClient = new HttpClient();
            using (var responseMessage = await httpClient.GetAsync(url))
            {
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    var fullName = Path.Combine(dir, responseMessage.Content.Headers.ContentDisposition.FileName.Trim('"'));
                    using (var fs = File.Open(fullName, FileMode.Create))
                    {
                        using (var responseStream = await responseMessage.Content.ReadAsStreamAsync())
                        {
                            await responseStream.CopyToAsync(fs);
                            return fullName;
                        }
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
