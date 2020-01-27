using System;
using swapi.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace swapi.Services
{
    public class GetSwapiData<T>
    {
        public async Task<T> ReturnData(string SwapiUri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(SwapiUri);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}