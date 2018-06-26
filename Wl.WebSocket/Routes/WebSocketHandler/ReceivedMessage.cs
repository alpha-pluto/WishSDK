
/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ReceivedMessage.cs
    文件功能描述：接收消息类

----------------------------------------------------------------*/
using System;

namespace Wl.WebSocket
{
    [Serializable]
    public class ReceivedMessage
    {
        public string Message { get; set; }
        public string SessionId { get; set; }
        public string FormId { get; set; }
    }
}
