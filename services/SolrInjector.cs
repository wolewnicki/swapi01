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
        private readonly ISolrOperations<PersonModel> _solrPeople;

        public SolrInjector(ISolrOperations<PersonModel> solrPeople)
        {
            _solrPeople = solrPeople;
        }
        public void AddToSolr(PersonModel indexable)
        {
            _solrPeople.Add(indexable);
            _solrPeople.CommitAsync();

        }
    }
}