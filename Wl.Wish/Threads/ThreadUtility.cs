/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ThreadUtility.cs
    文件功能描述：线程工具类

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wl.Wish.Threads
{
    public static class ThreadUtility
    {
        /// <summary>
        /// 异步线程容器
        /// </summary>
        public static Dictionary<string, Thread> AsynThreadCollection = new Dictionary<string, Thread>();//后台运行线程

        /// <summary>
        /// 注册线程
        /// </summary>
        public static void Register()
        {
            if (AsynThreadCollection.Count == 0)
            {
                {
                    WlMessageQueueThreadUtility wlMessageQueue = new WlMessageQueueThreadUtility();
                    Thread wlMessageQueueThread = new Thread(wlMessageQueue.Run) { Name = "WlMessageQueue" };
                    AsynThreadCollection.Add(wlMessageQueueThread.Name, wlMessageQueueThread);
                }

                AsynThreadCollection.Values.ToList().ForEach(z =>
                {
                    z.IsBackground = true;
                    z.Start();
                });//全部运行

            }
        }
    }
}
