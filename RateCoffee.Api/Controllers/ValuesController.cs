using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using RateCoffee.Service;

namespace RateCoffee.Api.Controllers
{
	public class ValuesController : ApiController
	{
        RateCoffee.Service.ICoffeeRepo _repo;

        public ValuesController(ICoffeeRepo repo)
        {
            _repo = repo;
        }

		//// GET api/values
		//[SwaggerOperation("GetAll")]
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}
		// GET api/values
		[SwaggerOperation("GetAllData")]
		public IEnumerable<string> Get()
		{
			var data = _repo.GetStuff();
			return data;
		}

		// GET api/values/5
		[SwaggerOperation("GetById")]
		[SwaggerResponse(HttpStatusCode.OK)]
		[SwaggerResponse(HttpStatusCode.NotFound)]
		public string Get(int id)
		{
            var data = _repo.Add(id.ToString());
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
