using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Threading.Tasks;

namespace swapi.Services
{
    public class PlanetService
    {
        private readonly GetRandomPlanet _getRandomPlanet;

        public PlanetService(GetRandomPlanet getRandomPlanet)
        {
            _getRandomPlanet = getRandomPlanet;
        }
        public async Task<PlanetModel> GetRandomPlanet()
            {
                return await _getRandomPlanet.ReturnRandomPlanet();
            }
    }
}