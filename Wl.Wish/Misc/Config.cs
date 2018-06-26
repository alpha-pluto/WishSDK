/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：Config.cs
    文件功能描述：全局设置
    
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish
{
    public static class Config
    {
        /// <summary>
        /// 请求超时设置（以毫秒为单位），默认为10秒。
        /// 说明：此处常量专为提供给方法的参数的默认值，不是方法内所有请求的默认超时时间。
        /// </summary>
        public const int TIME_OUT = 60 * 1000;

        private static bool _isDebug = false;//TODO:需要考虑分布式的情况，后期需要储存在缓存中

        /// <summary>
        /// 指定是否是Debug状态，如果是，系统会自动输出日志
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                return _isDebug;
            }

            set
            {
                _isDebug = value;
            }
        }

        /// <summary>
        /// JavaScriptSerializer 类接受的 JSON 字符串的最大长度
        /// </summary>
        public static int MaxJsonLength = int.MaxValue;//TODO:需要考虑分布式的情况，后期需要储存在缓存中

        /// <summary>
        /// 默认缓存键的第一级命名空间，默认值：DefaultCache
        /// </summary>
        public static string DefaultCacheNamespace = "DefaultCache";//TODO:需要考虑分布式的情况，后期需要储存在缓存中,或进行全局配置


        public static string RequestUriRoot = @"https://china-merchant.wish.com";


        public static string RequestUriRootSandbox = @"https://sandbox.merchant.wish.com";


    }
}
