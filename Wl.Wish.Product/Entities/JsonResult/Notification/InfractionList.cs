/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：InfractionList.cs
    文件功能描述：违规通知列表 实体( 从 Wish 返回  )

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
    public class InfractionList : WishJsonResult
    {
        public InfractionsResponseWrapper data { get; set; }
    }

    [Serializable]
    public class InfractionsResponse
    {
        public List<Wl.Wish.Entities.Response.InfractionWrapper> infractions { get; set; }
    }

    [Serializable]
    public class InfractionsResponseWrapper
    {
        public InfractionsResponse InfractionsResponse { get; set; }
    }
}
