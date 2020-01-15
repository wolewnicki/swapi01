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
        public int Id { get; set; }

        [SolrField("name_s")]
        public string Name { get; set; }
        
        [SolrField("age_i")]
        public int Age { get; set; }

        [SolrField("sex_s")]
        public string Sex { get; set; }
    }
}