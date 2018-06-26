using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class TagWrapper
    {
        public TagEntity Tag { get; set; }
    }

    [Serializable]
    public class TagEntity
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
