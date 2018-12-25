using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RateCoffee.Api.App_Start
{
    public class LoggingMiddleware : OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            //handle request logging
            var request = context.Request;

            await Next.Invoke(context);

            var response = context.Response;
            //handle response logging
        }

    }
}