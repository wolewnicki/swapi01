using System;
using System.Collections.Generic;
using SolrNet;
using swapi.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace swapi.Services
{
    public class SolrInjector<T>
    {
        private readonly ISolrOperations<T> _solrPeople;

        public SolrInjector(ISolrOperations<T> solrPeople)
        {
            _solrPeople = solrPeople;
        }
        public void AddToSolr(T indexable)
        {
            _solrPeople.AddAsync(indexable);
            _solrPeople.CommitAsync();

        }
    }
}

