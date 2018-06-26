/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Enums.cs
    文件功能描述：枚举类型

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish
{
    /// <summary>
    /// 会话类型
    /// </summary>
    public enum SessionType
    {
        Sandbox = 0,//使用沙盒环境，测试用
        Prod = 1//正式环境
    }

    /// <summary>
    /// CommonJsonSend中的http提交类型
    /// </summary>
    public enum CommonJsonSendType
    {
        GET,
        POST
    }

    /// <summary>
    /// 返回码（JSON）
    /// </summary>
    public enum ReturnCode
    {
        Busy = -1,
        Success = 0

    }

}
