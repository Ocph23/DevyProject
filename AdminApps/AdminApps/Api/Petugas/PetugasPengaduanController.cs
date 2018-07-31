using AdminLib.Domains;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminApps.Api.User
{
    public class PetugasPengaduanController : ApiController
    {
        private PengaduanDomain domain = new PengaduanDomain();
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var profile = await User.GetPetugas();
                var results = await domain.Get();
                var datas = results.Where(O => O.IdPetugas == profile.idpetugas).ToList();
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/AdminPelanggan/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {

                return Ok(await domain.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       

        // PUT: api/AdminPelanggan/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]PengaduanModel value)
        {
            try
            {
                return Ok(await domain.SaveChange(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/AdminPelanggan/5
       
    }
}
