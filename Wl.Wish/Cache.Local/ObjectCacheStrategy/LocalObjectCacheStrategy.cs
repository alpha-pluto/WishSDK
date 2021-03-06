﻿/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：LocalObjectCacheStrategy.cs
    文件功能描述：本地容器缓存。

 ----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wl.Wish.Containers;
using Wl.Wish.Cache;
namespace Wl.Wish.Cache
{

    /// <summary>
    /// 全局静态数据源帮助类
    /// </summary>
    public static class LocalObjectCacheHelper
    {
        /// <summary>
        /// 所有数据集合的列表
        /// </summary>
        internal static IDictionary<string, object> LocalObjectCache { get; set; }

        static LocalObjectCacheHelper()
        {
            LocalObjectCache = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// 本地容器缓存策略
    /// </summary>
    public class LocalObjectCacheStrategy : BaseCacheStrategy, IObjectCacheStrategy
    {
        #region 数据源

        private IDictionary<string, object> _cache = LocalObjectCacheHelper.LocalObjectCache;

        #endregion

        #region 单例

        /// <summary>
        /// LocalCacheStrategy的构造函数
        /// </summary>
        //LocalObjectCacheStrategy()
        //{
        //}

        //静态LocalCacheStrategy
        public static LocalObjectCacheStrategy Instance
        {
            get
            {
                return Nested.instance;//返回Nested类中的静态成员instance
            }
        }

        class Nested
        {
            static Nested()
            {
            }
            //将instance设为一个初始化的LocalCacheStrategy新实例
            internal static readonly LocalObjectCacheStrategy instance = new LocalObjectCacheStrategy();
        }


        #endregion

        #region IObjectCacheStrategy 成员

        public IContainerCacheStrategy ContainerCacheStrategy
        {
            get { return LocalContainerCacheStrategy.Instance; }
        }

        public void InsertToCache(string key, object value)
        {
            if (key == null || value == null)
            {
                return;
            }
            _cache[key] = value;
        }

        // void => virtual void
        public virtual void RemoveFromCache(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            _cache.Remove(cacheKey);
        }

        public object Get(string key, bool isFullKey = false)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            if (!CheckExisted(key, isFullKey))
            {
                return null;
                //InsertToCache(key, new ContainerItemCollection());
            }

            var cacheKey = GetFinalKey(key, isFullKey);
            return _cache[cacheKey];
        }

        //public IDictionary<string, TBag> GetAll<TBag>() where TBag : IBaseContainerBag
        //{
        //    var dic = new Dictionary<string, TBag>();
        //    var cacheList = GetAll();
        //    foreach (var baseContainerBag in cacheList)
        //    {
        //        if (baseContainerBag.Value is TBag)
        //        {
        //            dic[baseContainerBag.Key] = (TBag)baseContainerBag.Value;
        //        }
        //    }
        //    return dic;
        //}

        public IDictionary<string, object> GetAll()
        {
            return _cache;
        }

        // bool=> virtual bool
        public virtual bool CheckExisted(string key, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            return _cache.ContainsKey(cacheKey);
        }

        // long => virtual long
        public virtual long GetCount()
        {
            return _cache.Count;
        }

        public void Update(string key, object value, bool isFullKey = false)
        {
            var cacheKey = GetFinalKey(key, isFullKey);
            _cache[cacheKey] = value;
        }

        public void UpdateContainerBag(string key, object bag, bool isFullKey = false)
        {
            Update(key, bag, isFullKey);
        }

        #endregion

        #region ICacheLock
        public override ICacheLock BeginCacheLock(string resourceName, string key, int retryCount = 0, TimeSpan retryDelay = new TimeSpan())
        {
            return new LocalCacheLock(this, resourceName, key, retryCount, retryDelay);
        }

        #endregion
    }
}
