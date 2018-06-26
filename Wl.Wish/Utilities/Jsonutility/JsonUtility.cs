/*----------------------------------------------------------------
    Daniel.Zhang

    文件名：JsonUtility.cs
    文件功能描述：newtonsoft json serialization deserialization

----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wl.Wish.Utilities
{
    public class JsonUtility
    {
        /// <summary>
        /// 从json数据中反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonText)
        {
            T result = default(T);

            result = JsonConvert.DeserializeObject<T>(jsonText);

            return result;
        }

        /// <summary>
        /// 将实体序列化成json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetJsonText(object obj)
        {
            string jsonResult = string.Empty;

            jsonResult = JsonConvert.SerializeObject(obj);

            return jsonResult;
        }
    }
}
