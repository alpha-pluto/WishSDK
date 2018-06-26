/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：ProductDownloadTask.cs
    文件功能描述：商品下载任务的实体(与wish 对应)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    public class ProductDownloadTask
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
