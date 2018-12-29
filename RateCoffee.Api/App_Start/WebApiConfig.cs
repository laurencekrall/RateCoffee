using NLog;
using RateCoffee.Service;
using RateCoffee.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Lifetime;
using Unity.Injection;

namespace RateCoffee.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
            var container = new UnityContainer();
            container.RegisterType<ILogger>(new InjectionFactory(l => LogManager.GetCurrentClassLogger()));
            container.RegisterType<ICoffeeRepo, CoffeeRepo>();
            container.RegisterType<ICoffeeService, CoffeeService>();
            container.RegisterType<RateCoffeeContext>(new HierarchicalLifetimeManager(),new InjectionFactory(c => new RateCoffeeContext()));

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
