/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：UnRegisterClientIdExceptio.cs
    文件功能描述：未注册ClientId异常

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Exceptions
{
    public class UnRegisterClientIdException : WishException
    {
        public UnRegisterClientIdException(string clientId, string message, Exception inner = null)
            : base(message, inner)
        {
            ClientId = clientId;
        }
    }
}
