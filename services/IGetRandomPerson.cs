using System;
using System.Collections.Generic;
using System.Text;
using swapi.Models;
using System.Threading.Tasks;

namespace swapi.Services
{
    public interface IGetRandomPerson
    {
        Task<PersonModel> ReturnRandomPerson();
    }
}
