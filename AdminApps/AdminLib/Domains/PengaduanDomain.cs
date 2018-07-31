using AdminLib.Models;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public class PengaduanDomain : IBaseDomain<PengaduanModel>
    {
        public Task<bool> Delete(int id)
        {
            var model = new Pengaduan { IdPengaduan = id };
            return model.Delete();
        }

        public async Task<List<PengaduanModel>> Get()
        {
            var model = new Pengaduan();
            var result = await model.Get();
            List<PengaduanModel> list = new List<PengaduanModel>();
            foreach(var item in result)
            {
                list.Add(item.ConvertModel());
            }
            return list;
        }

        public async Task<PengaduanModel> GetById(int id)
        {
            var model = new Pengaduan() { IdPengaduan = id };
            var result = await model.GetById();
            return result.ConvertModel();
        }

        public async Task<PengaduanModel> SaveChange(PengaduanModel item)
        {

            var model = item.ConvertModel();
            var result = await model.SaveChange();
            return result.ConvertModel();
        }
    }
}
