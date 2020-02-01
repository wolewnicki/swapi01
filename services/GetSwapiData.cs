using System;
using swapi.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace swapi.Services
{
    public class GetData<T>
    {
        public async Task<RootObject<T>> ReturnData(string SwapiUri)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(SwapiUri);

            using var content = response.Content;
            var json = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RootObject<T>>(json);
        }
    }
}