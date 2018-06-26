/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：WebSocketRouteConfig.cs
    文件功能描述：自动配置WebSocket路由

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Wl.WebSocket
{
    public class WebSocketConfig
    {
        internal static Func<WebSocketMessageHandler> WebSocketMessageHandlerFunc { get; set; }

        /// <summary>
        /// 注册WebSocket路由规则
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var route = new WebSocketRoute("WlWebSocket", new WebSocketRouteHandler());
            routes.Add("WlWebSocketRoute", route);//WlWebSocket/{app}
        }

        /// <summary>
        /// 注册WebSocketMessageHandler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterMessageHandler<T>() where T : WebSocketMessageHandler, new()
        {
            WebSocketMessageHandlerFunc = () => new T();
        }
    }
}
