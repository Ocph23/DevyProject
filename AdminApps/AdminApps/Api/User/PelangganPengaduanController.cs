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
    public class PelangganPengaduanController : ApiController
    {
        private PengaduanDomain domain = new PengaduanDomain();
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var profile = await User.PelangganProfile();
                var results = await domain.Get();
                return Ok(results.Where(O=>O.IdPelanggan==profile.IdPelanggan).ToList());
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
        public async Task<IHttpActionResult> Post([FromBody]PengaduanModel value)
        {
            try
            {
                value.WaktuLapor = DateTime.Now;
                var pel = await User.PelangganProfile();
                value.IdPelanggan = pel.IdPelanggan;
                return Ok(await domain.SaveChange(value));
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
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                return Ok(await domain.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
