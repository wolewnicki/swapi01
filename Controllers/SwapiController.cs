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
        private readonly SwapiIndexer<PlanetModel> _swapiIndexer;

        public SwapiController(SwapiIndexer<PlanetModel> swapiIndexer)
        {
            _swapiIndexer = swapiIndexer;
        }

        [HttpPost]
        [Route("v1/swapi/SendData/")]
        public async Task<ActionResult> swapiIndexer()
        {
           var ObjectTest = await _swapiIndexer.ReturnCompleteSwapiList("https://swapi.co/api/planets");
            return Ok(ObjectTest);
        }
    }
}
