/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：OrderResultBase.cs
    文件功能描述：订单Api 的 基本主体 

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class OrderResultBase : WishJsonResult
    {
        public SimpleData data { get; set; }
    }

    [Serializable]
    public class SimpleData
    {
        public bool success { get; set; }
    }
}
