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
        private readonly ISwapiService _swapiService;

        private readonly SolrInjector _solrHandler;

        public SwapiController(ISwapiService swapiService, SolrInjector solrHandler)
        {
            _solrHandler = solrHandler;
            _swapiService = swapiService;
        }

        [HttpGet]
        [Route("v1/swapi/randomPerson/")]
        public async Task<ActionResult> GetRandomPerson()
        {
            var result = await _swapiService.GetRandomPerson();
            result.results.ForEach(_solrHandler.AddToSolr);

            return Ok();
        }

        public IActionResult AddToSolr(PersonModel result)
        {
            _solrHandler.AddToSolr(result);
            return Ok();
        }
    }
}
