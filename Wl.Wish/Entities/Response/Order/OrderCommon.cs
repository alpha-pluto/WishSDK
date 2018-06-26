/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：OrderCommon.cs
    文件功能描述：订单所用的公用变量

----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities
{
    /// <summary>
    /// 退货的理由
    /// </summary>
    public enum ResonCodeOfRefundOrCancel
    {
        Other = -1,//	其他
        Unfulfilled = 1,// 店铺无法履行订单
        Mistake = 18,//	误下单了
        TooLongDelivery = 20,//	配送时间过长
        MerchandiseNotSuitable = 22,//	商品不合适
        MerchandiseWrong = 23,//	收到错误的商品rec
        Fraud = 24,//	商品为假冒伪劣品
        Damaged = 25,//	商品已损坏
        MerchandiseNotMatchFunctionally = 26,//	商品功能与描述不符
        MerchandiseNotAsDescribed = 27,//	商品与产品描述不符
        WrongDelivery = 30,//	产品被配送至错误的地址
        WrongAddressProvided = 31,//	用户提供了错误的地址
        ReturnToShipper = 32,//shipper	商品退还至发货人
        IncompleteOrder = 33,//	Incomplete Order
        UnableToFulfilled = 34,//	店铺无法履行订单
        SaidDeliveredButNotReceived = 35,//	此件显示已妥投，但客户未收到。
        ReceivedWrong = 1001,//	Received the wrong color
        ItemOfPoorQuality = 1002,//	Item is of poor quality
        ProductListMissing = 1004,//	Product listing is missing information
        ItemNotExpected = 1005,//	Item did not meet expectations
        EmptyPackage = 1006//	Package was empty
    }
}
