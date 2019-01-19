using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using RateCoffee.Api.App_Start;

[assembly: OwinStartup(typeof(RateCoffee.Api.Startup))]

namespace RateCoffee.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.Use(typeof(LoggingMiddleware), NLog.LogManager.GetCurrentClassLogger());
            app.UseWebApi(config);
        }
    }
}
