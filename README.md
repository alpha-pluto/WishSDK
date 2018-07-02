# WishSDK
WishSDK,managing products,sales for wish.com
通过Api 向wish.com中的授权店铺发布商品，编辑商品，下载订单，
标识货运等操作

详细说明请见 WishApi.docx 和 容器说明.docx

==================以下为获得授权的概述================

1．	基本概念说明
  1)	Wish 店铺设置
    1.	Merchant Id
    Merchant Id 是 店铺在wish 平台上 对应的商家Id,用以区别wish 平台上的销售商

    2.	App Name
    App Name 是集成Api调用 的项目名称或是应用名称，只供参考，不作为程序参数

    3.	Client Id
    接入wish平台与本店铺对应的client id，用于 获取授权之类的操作
    
    4.	Client Secret
    接入wish平台上对应店铺的密钥串，用于获取授权之类的操作
    
    5.	Redirect URI
    接入 wish 平台上对应店铺的返回Url,用于接收预授权码，必须是安全链接，如 https://www.eastmall.vip/wish_return
  
  2)	Api调用参数说明
    每个调用函数都有sessionType 参数，此参数为SessionType 枚举类型，共有两个选值：SessionType.Prod 为正式环境的Api调用，SessionType.Sandbox 为沙盒环境的Api调用 

  3)	Wish返回结果集
    Wish 返回的结果为json，基本的数据如下
    {
      "message":"Tracking provider is not one of the accepted providers on Wish",
      "code":1000,
      "data":2003
    }
    其中 data 节点 视具体的调用返回结果而定，可能是数字，也可能是其他的复杂类型。Code为0表示调用成功，非零数字代表出错，Api调用 函数的返回结果集为根据相应的返回json的结构定义的实体。


2．	授权部分
  1)	获取预授权码Uri
      在Wish平台或是Wish 沙盒平台 上获取预授权码的Uri为 
      https://china-merchant.wish.com/oauth/authorize?client_id={client_id} 或
      https://sandbox.merchant.wish.com/oauth/authorize?client_id={client_id}
      这一步发送之后，客户会转向到授权页面，无论同意或拒绝，都会返回redirectUrl页面。
      如果用户同意授权，页面将跳转至 redirect_uri?code={authorization_code}。这里的code用于换取access_token ; 若用户禁止授权，则重定向后不会带上code参数

      函数定义：
      
      String GetAuthorizeUrl(string clientId, 
          string redirectUrl, 
          string grantType = "authorization_code",
          SessionType sessionType = SessionType.Prod);
          

      调用示例 ：
      
      string proAuthUrl = Wl.Wish.Open.OAuthAPIs.OAuthApi.GetAuthorizeUrl(
        clientId: "58d5c99a2bc5a20f60343036", 
        redirectUrl: @"https://eastmall.vip/WishApi/InstantShop.html", 
        sessionType: SessionType.Sandbox);

       此处的clientId 和 redirectUrl 必须与 wish平台上相应店铺中的信息完全一致。
      从wish返回的code为预授权码，有效期为5分钟，请在5分钟内换取access_token

  2)	获取AccessToken
    在wish 平台鉴权后，会引导到店铺设置中相应设定的returnUrl并带入code作为参数，此参数为预授权码，有效期5分钟；使用预授权码获取accesstoken 的函数用下
    
    函数定义：
    
    OAuthAccessTokenResult GetAccessToken(string clientId, 
      string clientSecret, 
      string preAuthCode,
      string redirectUrl, 
      SessionType sessionType = SessionType.Prod);
      
    调用示例：
    
    var accesstoken= Wl.Wish.Open.OAuthAPIs.OAuthApi.GetAccessToken(
      clientId:client_id,
      clientSecret:client_secret,
      preAuthCode:pre_auth_code,
      redirectUrl:redirect_url,
      sessionType:SessionType.Sandbox);

  3)	刷新AccessToken
    由于某些原因，需要更换access_token，可以使用 refresh_token 参数，此数据在上次获取access_token 时已经一并获取并与access_token  一起存入在某个数据仓库。
    函数定义：
    OAuthAccessTokenResult RefreshAccessToken(string clientId, 
      string clientSecret, 
      string refreshToken, 
      SessionType sessionType = SessionType.Prod);

    调用示例：
    var newAccessToken= RefreshAccessToken(
      clientId:client_id,
      clientSecret:client_secret,
      refreshToken:refresh_token,
      sessionType:SessionType.Sandbox
    );
    
  4)	测试 AccessToken
    获取的access_token 可以用此方法来测试是否正确
    函数定义 ：
    
    OAuthAccessTokenTestResult TestAccessToken(string accessToken, SessionType sessionType = SessionType.Prod)；
    
    调用示例：
    
    Var tokenTest= TestAccessToken(accessToken:access_token,sessionType:SessionType.Sandbox);

