using System;
using System.Collections.Generic;
using SolrNet;
using swapi.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace swapi.Models
{
    public class SolrInjector //: ISolrOperations<Person>
    {
        public void AddToSolr()
        {
            var N = new Person
            {
                Id = "1",
                Name = "Nico",
                Age = 18,
                Sex = "Male"
            };
            //ISolrOperations<Person>.Add(N);
            // do i have to create a document with this object??

        }
    }
}