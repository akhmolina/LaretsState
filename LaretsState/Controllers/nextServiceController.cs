using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LaretsState.Controllers
{
    public class nextServiceController : ApiController
    {
        state actualstate = state.Instance;

        // GET: api/nextService
        public serviceRecord Get()
        {
            return actualstate.getNextRecord();
        }

        // GET: api/nextService/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/nextService
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/nextService/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/nextService/5
        //public void Delete(int id)
        //{
        //}
    }
}
