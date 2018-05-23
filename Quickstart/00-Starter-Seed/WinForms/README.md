## Auth0 WindowsForms Sample

Make sure that `App.config` contains your application domain and clientID. Also, don't forget register `https://tutorials.auth0.com/mobile` as Allowed Callback URLs.

Hit F5 to start application.

## Usage

1. Install NuGet

  ~~~ps
  Install-Package Auth0.OidcClient.WinForms
  ~~~

2. Instantiate Auth0Client

  ~~~cs
  using Auth0.OidcClient;

  var client = new Auth0Client(new Auth0ClientOptions
  {
	Domain = "{YOUR_AUTH0_DOMAIN}",
	ClientId = "{YOUR_CLIENT_ID}"
  });
  ~~~

3. Trigger login (with Widget) 

  ~~~cs
  var loginResult = await client.LoginAsync();

  if (!loginResult.IsError)
  {
	Debug.WriteLine($"id_token: {loginResult.IdentityToken}");
    Debug.WriteLine($"access_token: {loginResult.AccessToken}");
	Debug.WriteLine($"name: {loginResult.User.FindFirst(c => c.Type == "name")?.Value}");
    Debug.WriteLine($"email: {loginResult.User.FindFirst(c => c.Type == "email")?.Value}");
  }
  ~~~

  ![](https://cdn2.auth0.com/docs/media/articles/native-platforms/wpf-winforms/wpf-winforms-step1.png)

## What is Auth0?

Auth0 helps you to:

* Add authentication with [multiple authentication sources](https://docs.auth0.com/identityproviders), either social like **Google, Facebook, Microsoft Account, LinkedIn, GitHub, Twitter, Box, Salesforce, amont others**, or enterprise identity systems like **Windows Azure AD, Google Apps, Active Directory, ADFS or any SAML Identity Provider**.
* Add authentication through more traditional **[username/password databases](https://docs.auth0.com/mysql-connection-tutorial)**.
* Add support for **[linking different user accounts](https://docs.auth0.com/link-accounts)** with the same user.
* Support for generating signed [Json Web Tokens](https://docs.auth0.com/jwt) to call your APIs and **flow the user identity** securely.
* Analytics of how, when and where users are logging in.
* Pull data from other sources and add it to the user profile, through [JavaScript rules](https://docs.auth0.com/rules).

## Create a free Auth0 Account

1. Go to [Auth0](https://auth0.com) and click Sign Up.
2. Use Google, GitHub or Microsoft Account to login.

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## Author

[Auth0](auth0.com)

## License

This project is licensed under the MIT license. See the [LICENSE](LICENSE) file for more info.