using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Open.Test
{
    [TestClass]
    public class JsonSerialize
    {
        [TestMethod]
        public void TestJsonSerialize()
        {
            var json = "{'message' : '','code' : 0,'data' : {'access_token' : '1qaz2wsx3edc4rfv5tgb','refresh_token' : 'mju7nhy6bgt5vfr4cde3','expires_in' : 86400,'expiry_time' : 1438922740}}";

            var helper = new Wl.Wish.Helpers.SerializerHelper();

            Wl.Wish.Open.OAuthAPIs.OAuthAccessTokenResult o = helper.GetObject<Wl.Wish.Open.OAuthAPIs.OAuthAccessTokenResult>(json);

            Console.Write(o.data.access_token);

        }

        [TestMethod]
        public void TestJsonString()
        {
            var serializerHelper = new Wl.Wish.Helpers.SerializerHelper();
            var data = new { access_token = "abcedfg" };
            var jsonString = serializerHelper.GetJsonString(data, null);

            Console.Write(jsonString);
        }

        [TestMethod]
        public void TestAnonymousClassRec()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            var t = new { client_id = "1232323", client_secret = "dfdfdfdf", code = "dfdfdf" };
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                sb.Append("&" + p.Name + "=" + Convert.ToString(p.GetValue(t)));
            }
            Console.Write(sb.ToString().Substring(1, sb.ToString().Length - 1));
        }

        [TestMethod]
        public void TestAccessToken()
        {
            var access_token = "b98350560abd4bfd8ec7e6f3a7851724";
            var ret = Wl.Wish.Open.OAuthAPIs.OAuthApi.TestAccessToken(access_token, SessionType.Sandbox);

            Console.Write(ret);
        }

        [TestMethod]
        public void TestRefreshAccessToken()
        {
            var client_id = "58d5c99a2bc5a20f60343036";
            var client_secret = "0f236e91dd4a47fc8b79aacfd0e2f638";
            var refresh_token = "48afe8b1683e421785c4438f32901f29";

            var ret = Wl.Wish.Open.OAuthAPIs.OAuthApi.RefreshAccessToken(client_id, client_secret, refresh_token, SessionType.Sandbox);

            Console.WriteLine(ret.data.access_token);
            Console.WriteLine(ret.data.refresh_token);

        }

    }
}
