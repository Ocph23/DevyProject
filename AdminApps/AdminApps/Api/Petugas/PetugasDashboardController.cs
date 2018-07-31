using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminApps.Api.Petugas
{
    public class PetugasDashboardController : ApiController
    {
        // GET: api/PetugasDashboard
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PetugasDashboard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PetugasDashboard
        public void Post([FromBody]string value)    
        {
        }

        // PUT: api/PetugasDashboard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PetugasDashboard/5
        public void Delete(int id)
        {
        }
    }
}
