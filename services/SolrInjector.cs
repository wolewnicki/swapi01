using System;
using System.Collections.Generic;
using SolrNet;
using swapi.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace swapi.Services
{
    public class SolrInjector
    {
        private readonly ISolrOperations<RootObject> _solrPeople;

        public SolrInjector(ISolrOperations<RootObject> solrPeople)
        {
            _solrPeople = solrPeople;
        }
        public void AddToSolr(RootObject indexable)
        {
            _solrPeople.Add(indexable);
            _solrPeople.CommitAsync();

        }
    }
}