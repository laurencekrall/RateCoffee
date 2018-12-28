using NLog;
using RateCoffee.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace RateCoffee.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
            var container = new UnityContainer();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<ICoffeeRepo, CoffeeRepo>();

            config.DependencyResolver = new UnityDependencyResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
