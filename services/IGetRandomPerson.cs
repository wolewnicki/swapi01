using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;

namespace swapi.Services
{
    public interface IGetRandomPerson
    {
        Task<PersonModel> ReturnRandomPersonBasedOnTag(string searchCriteria);
    }
}