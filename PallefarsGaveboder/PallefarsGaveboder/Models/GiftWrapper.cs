using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PallefarsGaveboder.Models
{
    public class GiftWrapper
    {
        private string connectionString = "http://localhost:63097/";
        private HttpClient ApiClient;
        public GiftWrapper()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Gift>> GetAll()
        {
            using(HttpResponseMessage response = await ApiClient.GetAsync(connectionString + "gift/get"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Gift>>(jsonString);
                }
            }
            return null;
        }

        public async Task<Gift> Add(Gift g)
        {
            var json = JsonConvert.SerializeObject(g);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            using(HttpResponseMessage response = await ApiClient.PostAsync(connectionString + "gift/post", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    return g;
                }
            }
            return null;
        }
        public async Task<Gift> Remove(Gift g)
        {
            using (HttpResponseMessage response = await ApiClient.DeleteAsync(connectionString + $"gift/Delete/{g.GiftNumber}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return g;
                }
            }
            return null;
        }
        public async Task<Gift> Put(Gift g)
        {
            var json = JsonConvert.SerializeObject(g);
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = await ApiClient.PutAsync(connectionString + "gift/Update", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    return g;
                }
            }
            return null;
        }
    }
}
