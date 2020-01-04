using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Threading.Tasks;

namespace swapi.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IGetRandomPlanet _getRandomPlanet;

        public PlanetService(IGetRandomPlanet getRandomPlanet)
        {
            _getRandomPlanet = getRandomPlanet;
        }
        public async Task<PlanetModel> GetRandomPlanet()
            {
                return await _getRandomPlanet.ReturnRandomPlanet();
            }
    }
}