using AdminLib.Models;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public class PemasanganDomain : IBaseDomain<PemasanganModel>
    {
        public async Task<bool> Delete(int id)
        {
            var data = new Pemasangan(id);
            return await data.Delete();
        }

        public async Task<List<PemasanganModel>> Get()
        {
            var data = new Pemasangan();
            var results = await data.Get();
            List<PemasanganModel> list = new List<PemasanganModel>();
            foreach (var item in results)
            {
                var item1 = OcphMapper.Mapper.Map<PemasanganModel>(item);
                list.Add(item1);
            }
            return list;
        }

        public async Task<PemasanganModel> GetById(int id)
        {
            var data = new Pemasangan(id);
            var result = await data.GetById();
            return result.ConvertModel();
        }

        public async Task<PemasanganModel> SaveChange(PemasanganModel item)
        {
            var data = item.ConvertModel();
            var result = await data.SaveChange();
            return result.ConvertModel();
        }
    }
}
