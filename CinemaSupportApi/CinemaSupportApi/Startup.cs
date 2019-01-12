using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;
using CinemaSupport.Data;
using CinemaSupport.Domain.Models;
using CinemaSupportApi;
using CinemaSupportApi.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity;
using Unity.AspNet.WebApi;

[assembly: OwinStartup(typeof(Startup))]

namespace CinemaSupportApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //ConfigureAuth(app);
            var container = UnityConfig.GetConfiguredContainer();

            ConfigureAuth(ref app, container);
            
            ConfigureWebApi(app, container);
        }
        #region WebApi
        private void ConfigureWebApi(IAppBuilder app, IUnityContainer container)
        {
            var config = new HttpConfiguration()
            {
                DependencyResolver = new UnityDependencyResolver(container)
            };
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.EnableCors();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };

            config.Formatters.JsonFormatter.SerializerSettings = JsonConvert.DefaultSettings();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //doto
            //config.Services.Replace(typeof(IExceptionLogger), new GlobalExceptionLogger())
            //config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler())

            app.Map("/api", map =>
            {
                config.MapHttpAttributeRoutes();
                map.UseWebApi(config);
            });

        }
        #endregion

        #region Owin
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }


        public void ConfigureAuth(ref IAppBuilder app, IUnityContainer container)
        {
            //DataProtectionProvider = app.GetDataProtectionProvider();

            //// Configure the db context, user manager and signin manager to use a single instance per request
            //app.CreatePerOwinContext(() => container.Resolve<CinemaSupportContext>());
            ////???????????app.CreatePerOwinContext(AuthContext.Create);
            ////app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            ////app.CreatePerOwinContext(() => container.Resolve<ApplicationUserManager>());
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            //app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //var myProvider = new ApplicationOAuthProvider();
            //OAuthOptions = new OAuthAuthorizationServerOptions
            //{
            //    TokenEndpointPath = new PathString("/Token"),
            //    AuthorizeEndpointPath = new PathString("/Account/Authorize"),
            //    Provider = myProvider,
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
            //    AllowInsecureHttp = true
            //};
            ////app.CreatePerOwinContext(() => container.Resolve<ApplicationUserManager>());
            //app.UseOAuthAuthorizationServer(OAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            //// Enable the application to use bearer tokens to authenticate users
            //app.UseOAuthBearerTokens(OAuthOptions);
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(() => container.Resolve<CinemaSupportContext>());
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);


        }
        #endregion


    }

}