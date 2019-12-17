using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;

namespace swapi.Services
{
    public interface ISwapiService
    {
        Task<PersonModel> GetRandomPersonBasedOnSearchCriteria(string searchCriteria);
    }
}