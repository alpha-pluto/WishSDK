/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：IContainerCacheStrategy.cs
    文件功能描述：容器缓存策略基类接口。

 ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wl.Wish.Containers;

namespace Wl.Wish.Cache
{
    public interface IContainerCacheStrategy : IBaseCacheStrategy<string, IBaseContainerBag>
    {
        /// <summary>
        /// 获取所有ContainerBag
        /// </summary>
        /// <typeparam name="TBag"></typeparam>
        /// <returns></returns>
        IDictionary<string, TBag> GetAll<TBag>() where TBag : IBaseContainerBag;

        /// <summary>
        /// 更新ContainerBag
        /// </summary>
        /// <param name="key"></param>
        /// <param name="containerBag"></param>
        /// <param name="isFullKey">是否已经是完整的Key，如果不是，则会调用一次GetFinalKey()方法</param>
        void UpdateContainerBag(string key, IBaseContainerBag containerBag, bool isFullKey = false);
    }
}
