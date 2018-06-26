/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：WishJsonResult.cs
    文件功能描述：JSON返回结果基类（用于API的接口调用等）

----------------------------------------------------------------*/
using System;

namespace Wl.Wish.Entities
{

    /// <summary>
    /// 所有JSON格式返回值的API返回结果中分页结果接口
    /// </summary>
    public interface IJsonPagingResult
    {
        string next { get; set; }

        string previous { get; set; }
    }

    /// <summary>
    /// 所有JSON格式返回值的API返回结果接口
    /// </summary>
    public interface IJsonResult
    {
        string message { get; set; }
        int code { get; set; }
        //object data { get; set; }
    }

    /// <summary>
    /// JSON返回结果
    /// </summary>
    [Serializable]
    public class WishJsonResult : IJsonResult
    {
        public string message { get; set; }

        public int code { get; set; }

        //public virtual object data { get; set; }

        public override string ToString()
        {
            return string.Format("WishJsonResult:{{message:'{0}',code:'{1}'}}", message, code);
        }

    }

    /// <summary>
    /// JSON分页结果
    /// </summary>
    [Serializable]
    public class Paging : IJsonPagingResult
    {
        public virtual string next { get; set; }

        public virtual string previous { get; set; }
    }
}
