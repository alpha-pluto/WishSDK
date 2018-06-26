/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：Reply.cs
    文件功能描述：回复实体 ( 与wish Ticket 对应 )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Reply
    {
        public string date { get; set; }

        public string image_urls { get; set; }

        public string message { get; set; }

        public string sender { get; set; }

        public string translated_message { get; set; }

        public string translated_message_zh { get; set; }

    }
}
