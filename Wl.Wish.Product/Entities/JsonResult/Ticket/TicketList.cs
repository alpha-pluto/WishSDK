/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：TicketList.cs
    文件功能描述：Ticket列表 (Wish 返回 的Ticket)

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
    public class TicketList : WishJsonResult
    {
        public List<TicketBaseWrapper> data { get; set; }

        public Wl.Wish.Entities.Paging paging { get; set; }
    }
}
