using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LaretsState.Controllers
{
    public class serviceRecordController : ApiController
    {
        // GET api/serviceRecord
        public IEnumerable<serviceRecord> Get()
        {
            return state.getRecords();
        }

        // GET api/serviceRecord/id
        public IHttpActionResult Get(int id)
        {
            var record = state.getRecords().FirstOrDefault((sr) => sr.id == id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }
      
    }
}
