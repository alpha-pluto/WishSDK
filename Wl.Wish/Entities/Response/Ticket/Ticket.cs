/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：Ticket.cs
    文件功能描述：Ticket实体基类 ( 与wish ticket 对应 )

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Ticket
    {
        public string close_date { get; set; }

        public string closed_by { get; set; }

        public string id { get; set; }

        public string label { get; set; }

        public string last_update_date { get; set; }

        public string merchant_id { get; set; }

        public string open_date { get; set; }

        public bool? photo_proof { get; set; }

        public string state { get; set; }

        public string state_id { get; set; }

        public string subject { get; set; }

        public string sublabel { get; set; }

        public string transaction_id { get; set; }



    }
}
