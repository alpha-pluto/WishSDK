/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：WishOpenException.cs
    文件功能描述：开放平台异常处理类

----------------------------------------------------------------*/

using System;
using Wl.Wish.Exceptions;
using Wl.Wish.Open.CommonAPIs;
using Wl.Wish.Open.Containers;

namespace Wl.Wish.Open.Exceptions
{
    public class WishOpenException : WishException
    {
        /// <summary>
        /// ComponentBag
        /// </summary>
        public AuthrizationBag AuthBag { get; set; }

        public WishOpenException(string message, AuthrizationBag authBag = null, Exception inner = null)
                : base(message, inner)
        {
            AuthBag = authBag;
        }
    }
}
