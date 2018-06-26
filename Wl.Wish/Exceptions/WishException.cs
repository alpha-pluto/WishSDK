/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：WishException.cs
    文件功能描述：Wish自定义异常基类
    

----------------------------------------------------------------*/
using System;

namespace Wl.Wish.Exceptions
{
    public class WishException : ApplicationException
    {

        public string AppName { get; set; }
        public string ClientId { get; set; }

        public WishException(string message, bool logged = false)
            : this(message, null, logged)
        {

        }

        public WishException(string message, Exception exception, bool logged = false)
            : base(message, exception)
        {
            if (!logged)
            {
                WishTrace.WishExceptionLog(this);
            }
        }

    }
}
