/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Feature.cs
    文件功能描述：Feature 实体( 从 Wish 返回  )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Feature
    {
        public string cn_title { get; set; }

        public string body { get; set; }

        public string title { get; set; }

        public string link { get; set; }

        public string cn_body { get; set; }

        public string cn_link { get; set; }

    }

    [Serializable]
    public class FeatureWrapper
    {
        public Feature Feature { get; set; }
    }


}
