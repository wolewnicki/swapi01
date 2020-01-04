using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using swapi.Services;

namespace swapi.Services
{
    public class GetRandomPlanet : IGetRandomPlanet
    {
        public async Task<PlanetModel> ReturnRandomPlanet()
        {
            using (var PlanetURL = new HttpClient())
            {
                var url = new Uri($"https://swapi.co/api/planets/{RandomTest.RandomPlanet()}");
                
                var response = await PlanetURL.GetAsync(url);

                string json;
                using (var PlanetObject = response.Content)
                {
                    json = await PlanetObject.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<PlanetModel>(json);
            }
        }
    }
}