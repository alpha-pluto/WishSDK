/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：DateTimeHelper.cs
    文件功能描述：时间处理

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix时间戳起始时间

        /// <summary>
        /// 转换DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromJson">DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromJson(long dateTimeFromJson)
        {
            return BaseTime.AddTicks((dateTimeFromJson + 8 * 60 * 60) * 10000000);
        }

        /// <summary>
        /// 转换DateTime时间到C#时间
        /// </summary>
        /// <param name="dateTimeFromJson">DateTime</param>
        /// <returns></returns>
        public static DateTime GetDateTimeFromJson(string dateTimeFromJson)
        {
            return GetDateTimeFromJson(long.Parse(dateTimeFromJson));
        }

        /// <summary>
        /// 获取DateTime（UNIX时间戳）
        /// </summary>
        /// <param name="dateTime">时间</param>
        /// <returns></returns>
        public static long GetWishDateTime(DateTime dateTime)
        {
            return (dateTime.Ticks - BaseTime.Ticks) / 10000000 - 8 * 60 * 60;
        }

    }
}
