/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Infraction.cs
    文件功能描述：系统更新回复消息 实体( 从 Wish 返回  )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Infraction
    {
        public string id { get; set; }

        public string link { get; set; }

    }

    [Serializable]
    public class InfractionWrapper
    {
        public Infraction Infraction { get; set; }
    }

}
