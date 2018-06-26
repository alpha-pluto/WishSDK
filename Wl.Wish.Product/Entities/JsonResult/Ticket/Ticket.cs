/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Ticker.cs
    文件功能描述：Ticket 的各类实体( 从 Wish 返回  )

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
    public class TicketBase : Wl.Wish.Entities.Response.Ticket
    {
        public Wl.Wish.Entities.Response.UserInfo UserInfo { get; set; }

        public List<OrderWrapper> items { get; set; }

        public List<ReplyWrapper> replies { get; set; }

    }

    [Serializable]
    public class TicketBaseWrapper
    {
        public TicketBase Ticket { get; set; }
    }

    [Serializable]
    public class TicketResult : WishJsonResult
    {
        public TicketBaseWrapper data { get; set; }
    }

    [Serializable]
    public class TicketResultBase : WishJsonResult
    {
        public SimpleData data { get; set; }
    }



}
