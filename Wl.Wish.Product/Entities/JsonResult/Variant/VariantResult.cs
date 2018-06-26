/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：VariantResult.cs
    文件功能描述：商品规格回馈数据

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
    public class VariantResult : WishJsonResult
    {
        public Wl.Wish.Entities.Response.VariantWrapper data { get; set; }
    }

}
