/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：EntityBase.cs
    文件功能描述：EntityBase

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wl.Wish.Entities
{
    /// <summary>
    /// 所有自定义实体的基础接口
    /// </summary>
    public interface IEntityBase
    {

    }

    //public class EntityBase : IEntityBase
    //{

    //}

    /// <summary>
    /// 生成JSON时忽略NULL对象
    /// </summary>
    public interface IJsonIgnoreNull : IEntityBase
    {

    }

    public class JsonIgnoreNull : IJsonIgnoreNull
    {

    }

    /// <summary>
    /// 类中有枚举在序列化的时候，需要转成字符串
    /// </summary>
    public interface IJsonEnumString : IEntityBase
    {

    }

}
