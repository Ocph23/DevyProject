using Newtonsoft.Json;
using SharedApp;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace AndroidApp.Services
{
    public class PengaduanServices : IDataStore<PengaduanModel>
    {
        private List<PengaduanModel> list = new List<PengaduanModel>();

        public async Task<bool> AddItemAsync(PengaduanModel item)
        {
            using (var service = new RestService())
            {
                var str = JsonConvert.SerializeObject(item);
                var result = await service.PostAsync("api/pelangganpengaduan",Helpers.Content(item));
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<PengaduanModel>(strResult);
                    if (value != null)
                        list.Add(value);
                    else
                        throw new SystemException("Data Tidak Tersimpan");

                    return true;
                }
                else
                {
                    var message = JsonConvert.DeserializeObject<MessageModel>(strResult);
                    throw new SystemException(message.Message);
                }
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            using (var service = new RestService())
            {
                var result = await service.DeleteAsync("api/pelangganpemasangan/" + id);
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<bool>(strResult);
                    if (value)
                    {
                        var item = list.Where(O => O.IdPengaduan == id).FirstOrDefault();
                        if (item != null)
                        {
                            list.Remove(item);
                        }
                    }

                    else
                        throw new SystemException("Data Tidak Tersimpan");

                    return true;
                }
                else
                {
                    var message = JsonConvert.DeserializeObject<MessageModel>(strResult);
                    throw new SystemException(message.Message);
                }
            }
        }

        public Task<PengaduanModel> GetItemAsync(int id)
        {
            var item = list.Where(O => O.IdPengaduan == id).FirstOrDefault();
            return Task.FromResult(item);
        }

        public async Task<IEnumerable<PengaduanModel>> GetItemsAsync(bool forceRefresh = false)
        {
            list.Clear();
            using (var service = new RestService())
            {
                var result = await service.GetAsync("api/pelangganpengaduan");
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var listConverter = JsonConvert.DeserializeObject<List<PengaduanModel>>(strResult);
                    foreach (var item in listConverter)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public async Task<bool> UpdateItemAsync(PengaduanModel item)
        {
            using (var service = new RestService())
            {
                var str = JsonConvert.SerializeObject(item);
                var result = await service.PutAsync("api/pelangganpengaduan", Helpers.Content(item));
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<PengaduanModel>(strResult);
                    if (value != null)
                        list.Add(value);
                    else
                        throw new SystemException("Data Tidak Tersimpan");

                    return true;
                }
                else
                {
                    var message = JsonConvert.DeserializeObject<MessageModel>(strResult);
                    throw new SystemException(message.Message);
                }
            }
        }

    }
}
