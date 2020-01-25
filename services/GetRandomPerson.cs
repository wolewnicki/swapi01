using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using swapi.Services;
using SolrNet;

namespace swapi.Services
{
    public class GetRandomPerson 
    {
        public async Task<RootObject> ReturnRandomPerson(string SwapiUri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(SwapiUri);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<RootObject>(json);
            }
        }
    }
}
