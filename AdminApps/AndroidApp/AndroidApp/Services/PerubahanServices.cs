using Newtonsoft.Json;
using SharedApp;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Services
{
    public class PerubahanServices : IDataStore<PemasanganModel>
    {
        private List<PemasanganModel> list = new List<PemasanganModel>();


        public async Task<bool> AddItemAsync(PemasanganModel item)
        {
            using (var service = new RestService())
            {
                var str = JsonConvert.SerializeObject(item);
                var result = await service.PostAsync("api/pelangganpemasangan",Helpers.Content(item));
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<PemasanganModel>(strResult);
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
                var result = await service.DeleteAsync("api/pelangganpemasangan/"+id);
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<bool>(strResult);
                    if (value)
                    {
                        var item = list.Where(O => O.idpemasangan == id).FirstOrDefault();
                        if(item!=null)
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

        public Task<PemasanganModel> GetItemAsync(int id)
        {
            var item = list.Where(O => O.idpemasangan == id).FirstOrDefault();
            return Task.FromResult(item);
        }

        public async Task<IEnumerable<PemasanganModel>> GetItemsAsync(bool forceRefresh = false)
        {
            list.Clear();
            using (var service= new RestService())
            {
                var result = await service.GetAsync("api/pelangganpemasangan");
                string strResult = await result.Content.ReadAsStringAsync();
                if(result.IsSuccessStatusCode)
                {
                    var listConverter = JsonConvert.DeserializeObject<List<PemasanganModel>>(strResult);
                    foreach(var item in listConverter)
                    {
                        list.Add(item);
                    }
                }
            }
            return list.Where(O => O.JenisPemasangan != JenisPemasangan.Baru);
        }

        public async Task<bool> UpdateItemAsync(PemasanganModel item)
        {
            using (var service = new RestService())
            {
                var str = JsonConvert.SerializeObject(item);
                var result = await service.PutAsync("api/pelangganpemasangan", Helpers.Content(item));
                string strResult = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var value = JsonConvert.DeserializeObject<PemasanganModel>(strResult);
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
