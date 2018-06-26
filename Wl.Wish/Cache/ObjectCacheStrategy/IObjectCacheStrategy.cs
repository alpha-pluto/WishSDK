/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：IObjectCacheStrategy.cs
    文件功能描述：所有以String类型为Key的缓存策略接口。

 ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Cache
{
    public interface IObjectCacheStrategy : IBaseCacheStrategy<string, object>
    {
        IContainerCacheStrategy ContainerCacheStrategy { get; }
    }
}
