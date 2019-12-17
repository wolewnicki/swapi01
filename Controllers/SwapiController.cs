﻿using System;
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

        public SwapiController(ISwapiService swapiService)
        {
            _swapiService = swapiService;
        }
        [HttpGet]
        [Route("v1/swapi/random/{searchCriteria}")]
        public async Task<ActionResult> GetRandomPerson(string serachCriteria)
        {
            var result = await _swapiService.GetRandomPersonBasedOnSearchCriteria(searchCriteria);

            return Ok(result);
        }
    }
}