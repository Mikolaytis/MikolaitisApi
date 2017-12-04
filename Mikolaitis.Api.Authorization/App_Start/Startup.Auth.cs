using System;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Mikolaitis.Api.Authorization.Identity;
using Mikolaitis.Api.Database.Repositories;
using Owin;

namespace Mikolaitis.Api.Authorization
{
	public partial class Startup
	{
	    public void ConfigureOAuth(IAppBuilder app)
	    {
	        var issuer = ConfigurationManager.AppSettings["issuer"];
            
            app.CreatePerOwinContext(() => new CustomUserManager(new CustomUserStore(new UsersAuthorizationStore())));

	        app.UseCookieAuthentication(new CookieAuthenticationOptions());
	        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
	        {
	            TokenEndpointPath = new PathString("/token"),
	            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
	            Provider = new CustomOAuthProvider(),
	            AccessTokenFormat = new CustomJwtFormat(issuer),
#if DEBUG
	            AllowInsecureHttp = true
#else
                AllowInsecureHttp = false
#endif
	        });
	    }
    }
}