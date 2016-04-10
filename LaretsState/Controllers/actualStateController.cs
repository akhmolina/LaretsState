using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LaretsState
{
    public class actualStateController : ApiController
    {
        state actualstate = state.Instance;

        // GET api/actualState
        public state Get()
        {
            return actualstate;
        }

        // GET api/actualState/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/actualState
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/actualState/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/actualState/5
        //public void Delete(int id)
        //{
        //}
    }
}