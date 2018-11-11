using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using CinemaSupportApi;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using Unity;
using Unity.AspNet.WebApi;

//[assembly: OwinStartup(typeof(Startup))]

namespace CinemaSupportApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            var container = UnityConfig.GetConfiguredContainer();

            ConfigureWebApi(app, container);
        }

        private void ConfigureWebApi(IAppBuilder app, IUnityContainer container)
        {
            var config = new HttpConfiguration()
            {
                DependencyResolver = new UnityDependencyResolver(container)
            };

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
    }
}