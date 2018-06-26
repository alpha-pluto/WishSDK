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

namespace Wl.Wish.Open
{

    /// <summary>
    /// 平台推送消息类型
    /// </summary>
    public enum RequestInfoType
    {
        /// <summary>
        /// 推送component_verify_ticket协议
        /// </summary>
        component_verify_ticket,
        /// <summary>
        /// 推送取消授权通知
        /// </summary>
        unauthorized,
        /// <summary>
        /// 更新授权
        /// </summary>
        updateauthorized,
        /// <summary>
        /// 授权成功通知
        /// </summary>
        authorized
    }

}
