/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ErrorJsonResultException.cs
    文件功能描述：JSON返回错误代码（比如token_access相关操作中使用）。

----------------------------------------------------------------*/
using System;
using Wl.Wish.Entities;

namespace Wl.Wish.Exceptions
{
    public class ErrorJsonResultException : WishException
    {
        public WishJsonResult JsonResult { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// ErrorJsonResultException
        /// </summary>
        /// <param name="message">异常消息</param>
        /// <param name="inner">内部异常</param>
        /// <param name="jsonResult">WxJsonResult</param>
        /// <param name="url">API地址</param>
        public ErrorJsonResultException(string message, Exception inner, WishJsonResult jsonResult, string url = null)
            : base(message, inner, true)
        {
            JsonResult = jsonResult;
            Url = url;

            WishTrace.ErrorJsonResultExceptionLog(this);
        }
    }
}
