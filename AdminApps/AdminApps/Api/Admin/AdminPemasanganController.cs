using AdminLib.Domains;
using SharedApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminApps.Api.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminPemasanganController : ApiController
    {
        // GET: api/AdminPemasangan
        private PemasanganDomain domain = new PemasanganDomain();
        // GET: api/AdminPelanggan
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var results = await domain.Get();
                return Ok(results.Where(O=>O.JenisPemasangan== SharedApp.JenisPemasangan.Baru).ToList());
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
        public async Task<IHttpActionResult> Put(int id, [FromBody]PemasanganModel value)
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
