using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AndroidApp.Services
{
    public class RestService : HttpClient
    {

        public RestService()
        {

            this.MaxResponseContentBufferSize = 256000;
            this.BaseAddress = new Uri(Helpers.Server);
            this.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            CekTokenAsync();
        }

        public RestService(string apiUrl)
        {
            BaseAddress = new Uri(apiUrl);
        }

        private async void CekTokenAsync()
        {
            var main = await Helpers.GetBaseApp();
            if (main != null && main.Token != null)
            {
                DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue(main.Token.token_type, main.Token.access_token);
            }
        }

        public async Task<AuthenticationToken> GenerateTokenAsync(string user, string password)
        {
            try
            {
                var str = string.Format("grant_type=password&username={0}&password={1}", user, password);
                var result = await PostAsync("Token", new StringContent(str, Encoding.UTF8));
                var content = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                  
                    var Token = JsonConvert.DeserializeObject<AuthenticationToken>(content);

                    if (Token != null)
                    {
                        Token.Email = user;
                    }

                    var main = await Helpers.GetBaseApp();
                    main.Token = Token;
                    return Token;
                }
                else
                {
                    throw new System.Exception(result.StatusCode.ToString());
                }

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }

        }
    }
}
