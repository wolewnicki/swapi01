using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Net.Http;
using Newtonsoft.Json;


namespace swapi.Services
{
    public class GetRandomPerson : IGetRandomPerson
    {
        public async Task<PersonModel> ReturnRandomPersonBasedOnTag(string searchCriteria)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"https://swapi.co/api/people/?search=r2");

                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<PersonModel>(json);
            }
        }
    }
}