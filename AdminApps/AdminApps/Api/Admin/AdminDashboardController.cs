using AdminLib.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminApps.Api.Admin
{
    public class AdminDashboardController : ApiController
    {

        DashboardDomain domain = new DashboardDomain();
      
        public async Task<IHttpActionResult> Get()
        {
           var result = await domain.GetAdminDashboard();
            return Ok(result);
        }

        
       
    }
}
