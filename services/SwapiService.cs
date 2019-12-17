using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;

namespace swapi.Services
{
    public class SwapiService : ISwapiService
    {
        private readonly IGetRandomPerson _getRandomPerson;

        public SwapiService(IGetRandomPerson getRandomPerson)
        {
            _getRandomPerson = getRandomPerson;
        }
        public async Task<PersonModel> GetRandomPersonBasedOnSearchCriteria(string searchCriteria)
        {
            return await _getRandomPerson.ReturnRandomPersonBasedOnTag(searchCriteria);
        }
    }
}