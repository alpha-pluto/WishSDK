/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：SystemUpdatesResponse.cs
    文件功能描述：系统更新回复 实体( 从 Wish 返回  )

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class SystemUpdatesResponse
    {
        public string id { get; set; }

        public string release_date { get; set; }

        public List<FeatureWrapper> features { get; set; }
    }

    [Serializable]
    public class SystemUpdatesResponseWrapper
    {
        public SystemUpdatesResponse SystemUpdatesResponse { get; set; }
    }
}
