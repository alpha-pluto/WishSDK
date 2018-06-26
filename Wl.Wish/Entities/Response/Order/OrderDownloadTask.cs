/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：OrderDownloadTask.cs
    文件功能描述：订单下载任务的实体(与wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class OrderDownloadTask
    {
        public string job_id { get; set; }

        public string status { get; set; }

        public int? total_count { get; set; }

        public int? processed_count { get; set; }

        public string download_link { get; set; }

        public string created_date { get; set; }

        public string start_run_time { get; set; }

        public string end_run_time { get; set; }

        public string message { get; set; }
    }
}
