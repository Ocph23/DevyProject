using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public class DashboardDomain
    {
        public async Task<DashboardModel> GetAdminDashboard()
        {
            var das = new DashboardModel();
            das.Petugas = await GetPetugasCount();
            das.Perubahan = await GetPerubahanCount();
            das.Pemasangan= await GetPemasanganCount();
            das.Pengaduan= await GetPengaduanCount();
            das.Pelanggan= await GetPelangganCount();

            return das;


        }

        private Task<int> GetPerubahanCount()
        {
            using (var db = new OcphDbContext())
            {
                SharedApp.JenisPemasangan jenis = SharedApp.JenisPemasangan.Baru;
                var res = db.Pemasangan.Where(O => O.JenisPemasangan != jenis).Count();
                return Task.FromResult(res);

            }   
        }

        private Task<int> GetPemasanganCount()
        {
            using (var db = new OcphDbContext())
            {
                SharedApp.JenisPemasangan jenis = SharedApp.JenisPemasangan.Baru; 
                var res = db.Pemasangan.Where(O=>O.JenisPemasangan== jenis).Count();
                return Task.FromResult(res);

            }
        }

        private Task<int> GetPengaduanCount()
        {
            using (var db = new OcphDbContext())
            {
                var res = db.Pengaduan.Select().Count();
                return Task.FromResult(res);

            }
        }

        private Task<int> GetPelangganCount()
        {
            using (var db = new OcphDbContext())
            {
                var res = db.Pelanggan.Select().Count();
                return Task.FromResult(res);

            }
        }

        private Task<int> GetPetugasCount()
        {
            using (var db = new OcphDbContext())
            {
                var res = db.Petugas.Select().Count();
                return Task.FromResult(res);

            }
        }
    }
}
