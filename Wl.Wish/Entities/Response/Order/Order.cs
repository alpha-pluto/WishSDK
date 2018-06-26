/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：Order.cs
    文件功能描述：订单实体(从Wish 返回结果)

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities.Response
{
    [Serializable]
    public class Order
    {
        public ShippingDetail ShippingDetail { get; set; }

        public string last_updated { get; set; }
        public string order_time { get; set; }
        public string order_id { get; set; }
        public string order_total { get; set; }
        public string product_id { get; set; }
        public string buyer_id { get; set; }
        public string quantity { get; set; }
        public string price { get; set; }
        public string cost { get; set; }
        public string shipping { get; set; }
        public string shipping_provider { get; set; }
        public string tracking_number { get; set; }
        public string shipped_date { get; set; }
        public string shipping_cost { get; set; }
        public string product_name { get; set; }
        public string product_image_url { get; set; }
        public string days_to_fulfill { get; set; }
        public string hours_to_fulfill { get; set; }
        public string sku { get; set; }
        public string state { get; set; }
        public string transaction_id { get; set; }
        public string tracking_confirmed { get; set; }
        public string tracking_confirmed_date { get; set; }
        public string variant_id { get; set; }
        public string refunded_by { get; set; }
        public string refunded_reason { get; set; }
        public string refunded_time { get; set; }
        public string size { get; set; }
        public string color { get; set; }

    }
}
