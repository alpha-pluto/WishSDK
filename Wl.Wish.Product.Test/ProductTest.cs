using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Wl.Wish.Product.CommonAPIs;
using Wl.Wish.Product.Entities;

namespace Wl.Wish.Product.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductCreateTest()
        {
            var product = new Wl.Wish.Entities.Request.Product();
            product.name = "red api ssss";
            product.sku = "123456789-15";
            product.description = "100";
            product.tags = "red,shoe,cool";
            product.main_image = "http://i.imgur.com/Q1a32kD.jpg";
            product.extra_images = "http://i.imgur.com/Cxagv.jpg|http://i.imgur.com/Cxagv.jpg";
            product.inventory = 100;
            product.price = 7.00m;
            product.shipping = 5.00m;

            product.shipping_time = "15-20";
            product.msrp = 5.60m;
            product.upc = "123456789012";
            product.brand = "COCACHEEE";

            var clientId = "58d5c99a2bc5a20f60343036";
            var accessToken = "e6fe5a822f7c4c05bcc7d060ca99170f";
            var clientSec = "0f236e91dd4a47fc8b79aacfd0e2f638";
            var preAuthCode = "c8cff54d7bf441d19fa8fec07d863801";
            var redirectUri = "https://vlan.com/WishApi/InstantShop.html";

            Wl.Wish.Product.Containers.AccessTokenContainer.Register(clientId: clientId, clientSecret: clientSec, accessToken: accessToken, expiresIn: 2592000, expiryTime: 1495700389, refreshToken: "48afe8b1683e421785c4438f32901f29", redirectUri: redirectUri, appName: "Instant shop");
            var result = Wl.Wish.Product.CommonAPIs.CommonApi.ProductCreate(clientId: clientId, accessToken: accessToken, product: product, sessionType: SessionType.Sandbox);


            Console.Write(result.data.Product.id);
        }

        [TestMethod]
        public void ProductUpdateTest()
        {
            var product = new Wl.Wish.Entities.Request.ProductToUpdate();
            product.brand = "Jeep Commandor";
            product.description = "Bracelets Type: Strand Bracelets Gender: Unisex Clasp Type: Easy-hook Material: Stone Metals Type: Zinc Alloy Length: 18cm-18.5cm and we can make custom size of the bracelets Setting Type: None Style: Classic Shape\\pattern: Round Chain Type: Link Chain Fine or Fashion: Fashion Item Type: Bracelets Color:: Black Size:: 8mm Material:: Lava stone beads is_customized: Yes Unit Type: piece Package Weight: 0.040kg (0.09lb.) Package Size: 15cm x 15cm x 5cm (5.91in x 5.91in x 1.97in)";
            product.id = "59006434d594f17a412090f3";
            product.name = "2016 New 18k Iced Out Gold Plated Gold Gunmetal MICRO JESUS PIECE Mini Pendant Chain Hip Hop Necklace gift(Color: Gold) 【neo golden】";
            product.tags = "elegant,perfect,attractive";
            product.landing_page_url = "http://weilan.com/p/s-1i889efedfe";

            var clientId = "58f046f3f186cf290caf2098";
            var accessToken = "f3239c9554b4435da31fbdcf9c86c509";
            var clientSec = "6c0031ccaf5743918c9f78bb84c9e8b2";
            var preAuthCode = "1585f7dbdc6649be89069456b25d7416";
            var redirectUri = "https://weilan.com/WishApi/LuckJewShop.html";

            Wl.Wish.Product.Containers.AccessTokenContainer.Register(clientId: clientId, clientSecret: clientSec, accessToken: accessToken, expiresIn: 2592000, expiryTime: 1495700389, refreshToken: "48afe8b1683e421785c4438f32901f29", redirectUri: redirectUri, appName: "Instant shop");
            var result = Wl.Wish.Product.CommonAPIs.CommonApi.ProductUpdate(clientId: clientId, accessToken: accessToken, product: product, sessionType: SessionType.Sandbox);


            Console.Write(result);
        }

        [TestMethod]
        public void ProductDisableTest()
        {
            var productId = "59006434d594f17a412090f3";
            var clientId = "58f046f3f186cf290caf2098";
            var accessToken = "f3239c9554b4435da31fbdcf9c86c509";
            var clientSec = "6c0031ccaf5743918c9f78bb84c9e8b2";
            var preAuthCode = "1585f7dbdc6649be89069456b25d7416";
            var redirectUri = "https://weilan.com/WishApi/LuckJewShop.html";

            Wl.Wish.Product.Containers.AccessTokenContainer.Register(clientId: clientId, clientSecret: clientSec, accessToken: accessToken, expiresIn: 2592000, expiryTime: 1495700389, refreshToken: "48afe8b1683e421785c4438f32901f29", redirectUri: redirectUri, appName: "Instant shop");
            var result = Wl.Wish.Product.CommonAPIs.CommonApi.ProductDisableViaId(clientId: clientId, accessToken: accessToken, productId: productId, sessionType: SessionType.Sandbox);


            Console.Write(result);
        }

        [TestMethod]
        public void ProductEnableTest()
        {
            var productId = "59006434d594f17a412090f3";
            var clientId = "58f046f3f186cf290caf2098";
            var accessToken = "f3239c9554b4435da31fbdcf9c86c509";
            var clientSec = "6c0031ccaf5743918c9f78bb84c9e8b2";
            var preAuthCode = "1585f7dbdc6649be89069456b25d7416";
            var redirectUri = "https://weilan.com/WishApi/LuckJewShop.html";

            Wl.Wish.Product.Containers.AccessTokenContainer.Register(clientId: clientId, clientSecret: clientSec, accessToken: accessToken, expiresIn: 2592000, expiryTime: 1495700389, refreshToken: "48afe8b1683e421785c4438f32901f29", redirectUri: redirectUri, appName: "Instant shop");
            var result = Wl.Wish.Product.CommonAPIs.CommonApi.ProductEnableViaId(clientId: clientId, accessToken: accessToken, productId: productId, sessionType: SessionType.Sandbox);


            Console.Write(result);
        }

    }
}
