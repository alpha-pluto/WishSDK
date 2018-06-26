/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：NotificationEntity.cs
    文件功能描述：Notification 实体( 从 Wish 返回  )

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class NotificationEntity
    {
        /// <summary>
        /// Wish's unique identifier for the notification
        /// </summary>
        public string id { get; set; }

        /// <summary>
        ///  The title of the notification
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///  The message content of the notification
        /// </summary>
        public string message { get; set; }

        /// <summary>
        ///   The permanent link to the notification
        /// </summary>
        public string perma_link { get; set; }

    }
}
