﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using RateCoffee.Service;
using NLog;
using RateCoffee.GoogleApi;

namespace RateCoffee.Api.Controllers
{
	public class ValuesController : ApiController
	{
        ICoffeeService _coffeeService;
        ILogger _logger;
        GoogleApiService _GoogleApiService;

        public T ServiceCall<T>(Func<T> method)
        {
            try
            {
                return method();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new Exception("An internal error occured");
            }
        }

        public ValuesController(ICoffeeService coffeeService, ILogger logger)
        {
            _coffeeService = coffeeService;
            _logger = logger;
            _GoogleApiService = new GoogleApiService(new InstantiatedImageAnnotatorClient());
        }

		// GET api/values
		[SwaggerOperation("GetAllData")]
		public IEnumerable<string> Get()
		{
            var data = _coffeeService.GetStuff();
            return data;
		}

		// GET api/values/5
		[SwaggerOperation("GetById")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public string Get(int id)
		{
            var data = _GoogleApiService.GetSimilar();
            return data.ToString();
        }

		// POST api/values
		[SwaggerOperation("Create")]
		[SwaggerResponse(HttpStatusCode.Created)]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		[SwaggerOperation("Update")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		[SwaggerOperation("Delete")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public void Delete(int id)
		{
		}
	}
}
