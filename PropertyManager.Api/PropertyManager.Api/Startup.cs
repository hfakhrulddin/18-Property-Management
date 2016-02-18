using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PropertyManager.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly:OwinStartup(typeof(PropertyManager.Api.Startup))] // Tell Owin to use this class Startup as a Startup class.//Adding behavier to the class.



namespace PropertyManager.Api
{
    public class Startup
    {
        public object CorsOption { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();// create config to pass it to WebApiConfig.cs
            WebApiConfig.Register(config);/// send this to the API startup.

            ConfigureOAuth(app);//the method below (next).

            app.UseCors(CorsOptions.AllowAll); // app please use Owin.

            app.UseWebApi(config); // app (Owin) use our new config.
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //Cofig Authentication 
            var authenticationOptions = new OAuthBearerAuthenticationOptions();
            app.UseOAuthBearerAuthentication(authenticationOptions);//app use the new object authenticationOptions.

            //Config Authorization
            var authorizationOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new PropertyManagerAuthorizationServerProvider()

            };
            app.UseOAuthAuthorizationServer(authorizationOptions);


        }




    }
}