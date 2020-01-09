using System;
using System.Collections.Generic;
using SolrNet;
using swapi.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


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
            
            _solrPeople.Add(N);
            _solrPeople.Commit();
        }
    }
}