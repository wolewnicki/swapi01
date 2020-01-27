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
        private readonly GetSwapiData<RootObject> _GetSwapiData;

        private readonly SolrInjector<PlanetModel> _solrHandler;

        public SwapiController(GetSwapiData<RootObject> GetSwapiData, SolrInjector<PlanetModel> solrHandler)
        {
            _solrHandler = solrHandler;
            _GetSwapiData = GetSwapiData;
        }

        [HttpPost]
        [Route("v1/swapi/SendData/")]
        public async Task<ActionResult> GetSwapiData()
        {
            int n = 1;

            RootObject JsonArray = await _GetSwapiData.ReturnData("https://swapi.co/api/planets");
            var AllPeople = new List<PlanetModel>(JsonArray.results);


            while(JsonArray.next != null)
            {
                JsonArray = await _GetSwapiData.ReturnData(JsonArray.next);
                JsonArray.results.ForEach(AllPeople.Add);

            }

            foreach (PlanetModel index in AllPeople)
            {
                index.Planet_Id = n++;
            }
            AllPeople.ForEach(_solrHandler.AddToSolr);
            return Ok(AllPeople[46]);
        }
    }
}
