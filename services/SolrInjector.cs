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
                Id = 4,
                Name = "Stephen",
                Age = 25,
                Sex = "Male"

            };

            _solrPeople.Add(N);
            _solrPeople.CommitAsync();

        }
    }
}