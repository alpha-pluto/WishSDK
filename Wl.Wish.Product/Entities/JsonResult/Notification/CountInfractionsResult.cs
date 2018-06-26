using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Entities;

namespace Wl.Wish.Product.Entities
{
    [Serializable]
    public class CountInfractionsResult : WishJsonResult
    {
        public CountInfractionsResponseWrapper data { get; set; }
    }

    [Serializable]
    public class CountInfractionsResponseWrapper
    {
        public Wl.Wish.Entities.Response.CountInfractionsResponse CountInfractionsResponse { get; set; }
    }

}
