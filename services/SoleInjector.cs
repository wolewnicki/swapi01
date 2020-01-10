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
        private readonly ISolrOperations<Person> _solrPeople;

        public SolrInjector(ISolrOperations<Person> solrPeople)
        {
            _solrPeople = solrPeople;
        }
        public void AddToSolr()
        {
            var N = new Person
            {
                Id = "1",
                Name = "Nico",
                Age = 18,
                Sex = "Male"

            };

            //_solrPeople.Add(C:\\swapi\\Nico.json);
            _solrPeople.Commit();

            var products = _solrPeople.Query(new SolrQuery("name: test"));
        }
    }
}