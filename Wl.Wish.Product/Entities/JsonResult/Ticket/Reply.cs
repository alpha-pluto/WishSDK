/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：Reply.cs
    文件功能描述：Ticket实体中Reply 子模型 (Wish 返回 的订单实体)

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
    public class ReplyWrapper
    {
        public Wl.Wish.Entities.Response.Reply Reply { get; set; }
    }
}
