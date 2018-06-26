﻿/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：WebSocketHelper.cs
    文件功能描述：WebSocket处理类

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.WebSockets;

namespace Wl.WebSocket
{
    public class WebSocketHelper
    {
        private readonly AspNetWebSocketContext _webSocketContext;
        private readonly System.Net.WebSockets.WebSocket _webSocket;
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// WebSocketHelper
        /// </summary>
        /// <param name="webSocketContext"></param>
        /// <param name="cancellationToken"></param>
        public WebSocketHelper(AspNetWebSocketContext webSocketContext, CancellationToken cancellationToken)
        {
            _webSocketContext = webSocketContext;
            _webSocket = webSocketContext.WebSocket;
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">文字消息</param>
        /// <returns></returns>
        public async Task SendMessage(string message)
        {
            var data = new
            {
                content = message,
                time = DateTime.Now.ToString()
            };

            var newString = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //String.Format("Hello, " + receiveString + " ! Time {0}", DateTime.Now.ToString());

            Byte[] bytes = System.Text.Encoding.UTF8.GetBytes(newString);
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes),
                              WebSocketMessageType.Text, true, _cancellationToken);
        }

    }
}