using Newtonsoft.Json;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Services
{
   public class AccountService
    {
        public PelangganModel Pelanggan { get; private set; }

        public async Task<bool> Login(string usernama,string password)
        {
            using (var service = new RestService())
            {
                var result = await service.GenerateTokenAsync(usernama, password);
                if (result != null)
                    return true;
                else
                    throw new SystemException("Gagal Login");
            }
        }



        public async Task<PelangganModel> GetProfile()
        {
            using (var res = new RestService())
            {
                var requset = await res.GetAsync("api/user/Profile");
                var result = await requset.Content.ReadAsStringAsync();
                if (requset.IsSuccessStatusCode)
                {
                    if (res != null)
                    {
                        Pelanggan = JsonConvert.DeserializeObject<PelangganModel>(result);
                    }
                }
            }

            return Pelanggan;

        }

        public async Task<bool> Register(RegisterModel model)
        {
            using (var res = new RestService())
            {
                var str = JsonConvert.SerializeObject(model);
                var requset = await res.PostAsJsonAsync("api/user/register",model);
                var result = await requset.Content.ReadAsStringAsync();
                if (requset.IsSuccessStatusCode)
                {
                    if (res != null)
                    {
                        Helpers.KodeRegister = result;
                        return true;
                    }
                    else
                        throw new SystemException("Gagal Register");
                }
                else
                {
                    throw new SystemException("Gagal Register");
                }
               
            }
        }

        internal async Task<bool> SaveProfile(PelangganModel model)
        {
            using (var res = new RestService())
            {
                var str = JsonConvert.SerializeObject(model);
                var result = await res.PutAsync("/api/User/Profile", Helpers.Content(model));
                var token = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    throw new SystemException("Gagal Tersimpan");
            }
        }

        internal async Task<bool> RequestNewPassword(string email)
        {
            using (var res = new RestService())
            {

                var str = "{Email:" + string.Format("'{0}'", email) +"}";
                var result = await res.PostAsync("/Account/ForgotPassword",new StringContent(str, Encoding.UTF8));
                var token = await result.Content.ReadAsStringAsync();
                if (token != null)
                {
                    Helpers.KodeRegister = token;
                    return true;
                }
                else
                    throw new SystemException("Gagal Register");
            }
        }
    }
}
