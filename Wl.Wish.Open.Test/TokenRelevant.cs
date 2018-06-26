using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wl.Wish.Open.Test
{
    [TestClass]
    public class TokenRelevant
    {
        [TestMethod]
        public void TestPreAuthcodeUrl()
        {
            string proAuthUrl = Wl.Wish.Open.OAuthAPIs.OAuthApi.GetAuthorizeUrl(clientId: "58d5c99a2bc5a20f60343036", redirectUrl: @"https://vlan.com/WishApi/InstantShop.html", sessionType: SessionType.Sandbox);
            Console.WriteLine(proAuthUrl);
        }

        [TestMethod]
        public void TestGetAccessToken()
        {
            var client_id = "58d5c99a2bc5a20f60343036";
            var client_secret = "0f236e91dd4a47fc8b79aacfd0e2f638";
            var redirect_uri = @"https://vlan.com/WishApi/InstantShop.html";
            var pre_auth_code = "dc5f03bc818844c1af8be1b61f62ddef";

            var accessToken = Wl.Wish.Open.OAuthAPIs.OAuthApi.GetAccessToken(clientId: client_id, clientSecret: client_secret, redirectUrl: redirect_uri, preAuthCode: pre_auth_code, sessionType: SessionType.Sandbox);
            Console.WriteLine("accessToken {0} , refreshToken {1}", accessToken.data.access_token, accessToken.data.refresh_token);
        }

        [TestMethod]
        public void TestAccessToken()
        {
            var access_token = "68d17c0a285d47169f7c11c8a909be1b";
            var token = Wl.Wish.Open.OAuthAPIs.OAuthApi.TestAccessToken(accessToken: access_token, sessionType: SessionType.Sandbox);
            Console.WriteLine("merchant_id {0}", token.data.merchant_id);
        }
    }
}
