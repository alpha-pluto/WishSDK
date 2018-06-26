/*----------------------------------------------------------------
    Daniel.Zhang
    
    文件名：ShippingDetail.cs
    文件功能描述：发货详情(Wish 返回 的订单实体中的发货详情部分)

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class ShippingDetail
    {
        public string city { get; set; }

        public string country { get; set; }

        public string name { get; set; }

        public string phone_number { get; set; }

        public string state { get; set; }

        public string street_address1 { get; set; }

        public string street_address2 { get; set; }

        public string street_address3 { get; set; }

        public string zipcode { get; set; }
    }
}
