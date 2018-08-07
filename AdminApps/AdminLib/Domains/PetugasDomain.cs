using AdminLib.Models;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public class PetugasDomain : IBaseDomain<PetugasModel>
    {
        public async Task<bool> Delete(int id)
        {
            var dto = new Petugas() {idpetugas=id };
            var isDeleted = await dto.Delete();
            return isDeleted;
        }

        public async Task<List<PetugasModel>> Get()
        {
            var dto = new Petugas();
            var model = await dto.Get();
            var list = new List<PetugasModel>();
            foreach(var item in model)
            {
                list.Add(item.ConvertModel());
            }
            return list;
        }

        public async Task<PetugasModel> GetPetugasByUserId(string userid)
        {
            var dto = new Petugas() { UserId=userid };
            var model = await dto.GetByUserId();
            return model.ConvertModel();
        }

        public async Task<PetugasModel> GetById(int id)
        {
            var dto = new Petugas() { idpetugas=id};
            var model = await dto.GetById();
            return model.ConvertModel();
        }

        public async Task<PetugasModel> SaveChange(PetugasModel item)
        {
            var dto = OcphMapper.Mapper.Map<Petugas>(item);
            var model = await dto.SaveChange();
            return model.ConvertModel();
        }
    }
}