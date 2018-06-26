﻿/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：BaseCacheLock.cs
    文件功能描述：缓存锁。

 ----------------------------------------------------------------*/
using System;

namespace Wl.Wish.Cache
{
    /// <summary>
    /// 缓存同步锁基类
    /// </summary>
    public abstract class BaseCacheLock : ICacheLock
    {
        protected string _resourceName;
        protected IBaseCacheStrategy _cacheStrategy;
        protected int _retryCount;
        protected TimeSpan _retryDelay;

        public bool LockSuccessful { get; set; }

        protected BaseCacheLock(IBaseCacheStrategy strategy, string resourceName, string key, int retryCount, TimeSpan retryDelay)
        {
            _cacheStrategy = strategy;
            _resourceName = resourceName + key;/*加上Key可以针对某个AppId加锁*/
            _retryCount = retryCount;
            _retryDelay = retryDelay;
        }

        /// <summary>
        /// 立即开始锁定，需要在子类的构造函数中执行
        /// </summary>
        /// <returns></returns>
        protected ICacheLock LockNow()
        {
            if (_retryCount != 0 && _retryDelay.Ticks != 0)
            {
                LockSuccessful = Lock(_resourceName, _retryCount, _retryDelay);
            }
            else
            {
                LockSuccessful = Lock(_resourceName);
            }
            return this;
        }

        public void Dispose()
        {
            UnLock(_resourceName);
        }

        public abstract bool Lock(string resourceName);

        public abstract bool Lock(string resourceName, int retryCount, TimeSpan retryDelay);

        public abstract void UnLock(string resourceName);


    }
}
