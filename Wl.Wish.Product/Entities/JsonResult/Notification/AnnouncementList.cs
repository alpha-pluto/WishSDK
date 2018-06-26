
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class AnnouncementList : WishJsonResult
    {
        public List<AnnouncementWrapper> data { get; set; }
    }

    [Serializable]
    public class AnnouncementWrapper
    {
        public Wl.Wish.Entities.Response.Announcement GetBDAnnResponse { get; set; }
    }

}
