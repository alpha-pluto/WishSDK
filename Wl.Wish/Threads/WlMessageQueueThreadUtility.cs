/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：WlMessageQueueThreadUtility.cs
    文件功能描述：WlMessageQueue消息队列线程处理

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wl.Wish.MessageQueue;

namespace Wl.Wish.Threads
{

    /// <summary>
    /// WlMessageQueue线程自动处理
    /// </summary>
    public class WlMessageQueueThreadUtility
    {
        private readonly int _sleepMilliSeconds;

        public WlMessageQueueThreadUtility(int sleepMilliSeconds = 1000)
        {
            _sleepMilliSeconds = sleepMilliSeconds;
        }

        /// <summary>
        /// 析构函数，将未处理的队列处理掉
        /// </summary>
        ~WlMessageQueueThreadUtility()
        {
            try
            {
                var mq = new WlMessageQueue();
                System.Diagnostics.Trace.WriteLine(string.Format("WlMessageQueueThreadUtility执行析构函数"));
                System.Diagnostics.Trace.WriteLine(string.Format("当前队列数量：{0}", mq.GetCount()));

                WlMessageQueue.OperateQueue();//处理队列
            }
            catch (Exception ex)
            {
                //此处添加日志
                System.Diagnostics.Trace.WriteLine(string.Format("WlMessageQueueThreadUtility执行析构函数错误：{0}", ex.Message));
            }
        }

        /// <summary>
        /// 启动线程轮询
        /// </summary>
        public void Run()
        {
            do
            {
                WlMessageQueue.OperateQueue();
                Thread.Sleep(_sleepMilliSeconds);
            } while (true);
        }
    }
}
