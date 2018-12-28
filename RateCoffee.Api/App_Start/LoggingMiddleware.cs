using Microsoft.Owin;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RateCoffee.Api.App_Start
{
    public class LoggingMiddleware : OwinMiddleware
    {
        private ILogger _logger;

        public LoggingMiddleware(OwinMiddleware next, ILogger logger)
            : base(next)
        {
            _logger = logger;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var req = HttpContext.Current.Request;
            HttpResponse httpResponse = HttpContext.Current.Response;

            StreamHelper inputCapture = new StreamHelper(req.Filter);
            StreamHelper outputCapture = new StreamHelper(httpResponse.Filter);

            httpResponse.Filter = outputCapture;

            // Buffering Owin response if any 

            IOwinResponse owinResponse = context.Response;
            Stream owinResponseStream = owinResponse.Body;
            owinResponse.Body = new MemoryStream();

            await Next.Invoke(context);

            if (outputCapture.CapturedData.Length == 0)
            {
                owinResponse.Body.Position = 0;
                await owinResponse.Body.CopyToAsync(owinResponseStream);
            }
            else
            {
                // owin response body not filled for MVC calls
                outputCapture.CapturedData.Position = 0;
                outputCapture.CapturedData.CopyTo(owinResponse.Body);
            }

            owinResponse.Body.Seek(0, SeekOrigin.Begin);

            var responseBody = new StreamReader(owinResponse.Body).ReadToEnd();
            var reqBody = new StreamReader(inputCapture).ReadToEnd();

            _logger.Info(reqBody);
            _logger.Info(responseBody);
        }
    }
}
