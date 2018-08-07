using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminApps.Api
{
    [Authorize]
    public class UserProfileController : ApiController
    {
        // GET: api/UserProfile
        public async Task<IHttpActionResult> Get()
        {
            PetugasModel profile = await User.GetPetugas();
            return Ok(profile);
        }

        // GET: api/UserProfile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserProfile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserProfile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserProfile/5
        public void Delete(int id)
        {
        }
    }
}
