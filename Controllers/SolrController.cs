using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using swapi.Services;
using swapi.Models;
using SolrNet;


namespace swapi.Controllers
{
    public class SolrController : ControllerBase
    {
        private readonly SolrInjector _solrHandler;

        public SolrController(SolrInjector solrHandler)
        {
            _solrHandler = solrHandler;
        }

        [HttpPost]
        [Route("v1/swapi/SendToSolr/")]

        public Task<ActionResult> AddToSolr()
        {
            var result = _solrHandler.AddToSolr();
        }
    }    
}