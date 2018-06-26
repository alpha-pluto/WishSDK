/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：VariantList.cs
    文件功能描述：开放平台分页商品规格实体

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
    public class VariantList : WishJsonResult
    {
        public Wl.Wish.Entities.Paging paging { get; set; }

        public List<Wl.Wish.Entities.Response.VariantWrapper> data { get; set; }
    }
}
