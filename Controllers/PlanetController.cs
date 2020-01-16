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
    public class PlanetController : ControllerBase
    {
        private readonly PlanetService _planetService;

        public PlanetController(PlanetService planetService)
        {
            _planetService = planetService;
        }
        
        [HttpGet]
        [Route("v1/swapi/randomPlanet")]

        public async Task<ActionResult> GetRandomPlanet()
        {
            var PlanetResult = await _planetService.GetRandomPlanet();

            return Ok(PlanetResult);
        }
    }
}
