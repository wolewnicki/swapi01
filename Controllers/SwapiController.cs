using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using swapi.Services;
using swapi.Models;

namespace swapi.Controllers
{
    public class SwapiController : ControllerBase
    {
        private readonly GetRandomPerson _GetRandomPerson;

        private readonly SolrInjector<PersonModel> _solrHandler;

        public SwapiController(GetRandomPerson GetRandomPerson, SolrInjector<PersonModel> solrHandler)
        {
            _solrHandler = solrHandler;
            _GetRandomPerson = GetRandomPerson;
        }

        [HttpPost]
        [Route("v1/swapi/randomPerson/")]
        public async Task<ActionResult> GetRandomPerson()
        {
            int n = 1;
            int p = 1;

            RootObject JsonArray = await _GetRandomPerson.ReturnRandomPerson($"https://swapi.co/api/people/?page={p}");
            var AllPeople = new List<PersonModel>(JsonArray.results);


            while(JsonArray.next != null)
            {
                JsonArray = await _GetRandomPerson.ReturnRandomPerson(JsonArray.next);
                JsonArray.results.ForEach(AllPeople.Add);

            }

            foreach (PersonModel index in AllPeople)
            {
                index.Id = n++;
            }
            AllPeople.ForEach(_solrHandler.AddToSolr);
            return Ok(AllPeople[68]);
        }
    }
}
