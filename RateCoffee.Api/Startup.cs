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
            app.Use<LoggingMiddleware>();
            app.UseWebApi(config);
        }
    }
}
