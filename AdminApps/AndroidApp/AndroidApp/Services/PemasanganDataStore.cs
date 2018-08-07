using Newtonsoft.Json;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Services
{
    public class PemasanganDataStore : IDataStore<PemasanganModel>
    {

        private List<PemasanganModel> list = new List<PemasanganModel>();
        private bool isInstant = false;


        public Task<bool> AddItemAsync(PemasanganModel item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            list.Clear();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PemasanganModel> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PemasanganModel>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh == true)
                isInstant = false;

            if (isInstant)
                return list.AsEnumerable();
            else
            {
                isInstant = true;
                using (var res = new RestService())
                {
                    var result = await res.GetStringAsync("api/obat");
                    list = JsonConvert.DeserializeObject<List<PemasanganModel>>(result);
                }
                return list.AsEnumerable();
            }



        }

        public Task<bool> UpdateItemAsync(PemasanganModel item)
        {
            throw new NotImplementedException();
        }
    }
}
