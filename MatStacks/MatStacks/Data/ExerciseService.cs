using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Matstacks.Data
{
    public class ExerciseService
    {
        private string connectionString = "http://localhost:49519/";
        private HttpClient ApiClient;
        public ExerciseService()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Exercise>> GetExercises()
        {
            using(HttpResponseMessage response = await ApiClient.GetAsync(connectionString + "exercise"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Exercise>>(jsonString);
                }
                return null;
            }
        }
    }
}
