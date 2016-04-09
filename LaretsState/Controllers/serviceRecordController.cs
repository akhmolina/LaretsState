using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LaretsState.Controllers
{
    public class serviceRecordController : ApiController
    {
        state actualstate = state.Instance;

        // GET: api/serviceRecord
        public IEnumerable<serviceRecord> Get()
        {
            return actualstate.plan;
        }

        // GET: api/serviceRecord/5
        public IHttpActionResult Get(int id)
        {
            var record = actualstate.plan.FirstOrDefault((sr) => sr.id == id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // POST: api/serviceRecord
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/serviceRecord/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/serviceRecord/5
        //public void Delete(int id)
        //{
        //}
    }
}
