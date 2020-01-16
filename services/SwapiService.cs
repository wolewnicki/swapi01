using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Threading.Tasks;

namespace swapi.Services
{
    public class SwapiService 
    {
        private readonly GetRandomPerson _getRandomPerson;

        public SwapiService(GetRandomPerson getRandomPerson)
        {
            _getRandomPerson = getRandomPerson;
        }
        public async Task<RootObject> GetRandomPerson()
        {
            return await _getRandomPerson.ReturnRandomPerson();
        }
    }
}
