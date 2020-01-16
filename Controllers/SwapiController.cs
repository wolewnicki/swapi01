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
        private readonly SwapiService _swapiService;

        private readonly SolrInjector _solrHandler;

        public SwapiController(SwapiService swapiService, SolrInjector solrHandler)
        {
            _solrHandler = solrHandler;
            _swapiService = swapiService;
        }

        [HttpPost]
        [Route("v1/swapi/randomPerson/")]
        public async Task<ActionResult> GetRandomPerson()
        {
            int n = 1;
            var JsonArray = await _swapiService.GetRandomPerson();
            foreach (PersonModel index in JsonArray.results)
            {
                index.Id = n++;
            }

            JsonArray.results.ForEach(_solrHandler.AddToSolr);
            return Ok(JsonArray.results[2]);
        }

//         public IActionResult AddToSolr(PersonModel JsonArray)
//         {
//             _solrHandler.AddToSolr(JsonArray);
//             return Ok();
//         }
    }
}
