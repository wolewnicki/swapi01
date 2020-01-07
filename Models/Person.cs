using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapi.Models
{
    public class Person
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("name")]
        public string Name { get; set; }
        
        [SolrField("age")]
        public int Age { get; set; }

        [SolrField("sex")]
        public string Sex { get; set; }
    }
}