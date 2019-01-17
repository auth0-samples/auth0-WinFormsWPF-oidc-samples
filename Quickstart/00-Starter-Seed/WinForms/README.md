# Auth0 WindowsForms Sample
<img src="https://img.shields.io/badge/community-driven-brightgreen.svg"/> <br>

Samples for using the Auth0 OidcClient with Windows Forms / WPF applications

This repo is supported and maintained by Community Developers, not Auth0. For more information about different support levels check https://auth0.com/docs/support/matrix .

## Getting started

Make sure that `App.config` contains your application domain and clientID. Also, don't forget register `https://tutorials.auth0.com/mobile` as Allowed Callback URLs.

Hit F5 to start application.

## Usage

**1. Install NuGet**

~~~ps
Install-Package Auth0.OidcClient.WinForms
~~~

**2. Instantiate Auth0Client**

~~~cs
using Auth0.OidcClient;

var client = new Auth0Client(new Auth0ClientOptions
{
Domain = "{YOUR_AUTH0_DOMAIN}",
ClientId = "{YOUR_CLIENT_ID}"
});
~~~

**3. Trigger login (with Widget)**

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

## Contribute

Feel like contributing to this repo? We're glad to hear that! Before you start contributing please visit our [Contributing Guideline](https://github.com/auth0-community/getting-started/blob/master/CONTRIBUTION.md).

Here you can also find the [PR template](https://github.com/auth0-community/auth0-WinFormsWPF-oidc-samples/blob/master/PULL_REQUEST_TEMPLATE.md) to fill once creating a PR. It will automatically appear once you open a pull request.

## Issues Reporting

Spotted a bug or any other kind of issue? We're just humans and we're always waiting for constructive feedback! Check our section on how to [report issues](https://github.com/auth0-community/getting-started/blob/master/CONTRIBUTION.md#issues)!

Here you can also find the [Issue template](https://github.com/auth0-community/auth0-WinFormsWPF-oidc-samples/blob/master/ISSUE_TEMPLATE.md) to fill once opening a new issue. It will automatically appear once you create an issue.

## Repo Community

Feel like PRs and issues are not enough? Want to dive into further discussion about the tool? We created topics for each Auth0 Community repo so that you can join discussion on stack available on our repos. Here it is for this one: [auth0-winformswpf-oidc-samples](https://community.auth0.com/t/auth0-community-oss-auth0-winformswpf-oidc-samples/15980)

<a href="https://community.auth0.com/">
<img src="/Assets/join_auth0_community_badge.png"/>
</a>

## License

This project is licensed under the MIT license. See the [LICENSE](https://github.com/auth0-community/auth0-WinFormsWPF-oidc-samples/blob/master/LICENSE) file for more info.

## What is Auth0?

Auth0 helps you to:

* Add authentication with [multiple authentication sources](https://docs.auth0.com/identityproviders), either social like
* Google
* Facebook
* Microsoft
* Linkedin
* GitHub
* Twitter
* Box
* Salesforce
* etc.

**or** enterprise identity systems like:
* Windows Azure AD
* Google Apps
* Active Directory
* ADFS
* Any SAML Identity Provider

* Add authentication through more traditional [username/password databases](https://docs.auth0.com/mysql-connection-tutorial)
* Add support for [linking different user accounts](https://docs.auth0.com/link-accounts) with the same user
* Support for generating signed [JSON Web Tokens](https://docs.auth0.com/jwt) to call your APIs and create user identity flow securely
* Analytics of how, when and where users are logging in
* Pull data from other sources and add it to user profile, through [JavaScript rules](https://docs.auth0.com/rules)

## Create a free Auth0 account

* Go to [Auth0 website](https://auth0.com/signup)
* Hit the **SIGN UP** button in the upper-right corner
