/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ProductResultBase.cs
    文件功能描述：商品回馈基本数据

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
    public class ProductResultBase : WishJsonResult
    {
        public object data { get; set; }
    }
}
