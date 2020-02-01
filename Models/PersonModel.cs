using System;
using System.Collections.Generic;
using System.Text;
using SolrNet.Attributes;

namespace swapi.Models
{
    public class PersonModel : IBaseSwapiModel 
    {
        [SolrUniqueKey("id")]
        public string Id { get => $"person-{TempId}";}
        public int TempId { get; set; }
        [SolrField("name_s")]
        public string name { get; set; }
        [SolrField("height_s")]
       public string height { get; set; }
       [SolrField("mass_s")]
        public string mass { get; set; }
        [SolrField("hair_color_s")]
        public string hair_color { get; set; }
        [SolrField("skin_color_s")]
        public string skin_color { get; set; }
        [SolrField("eye_color_s")]
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        [SolrField("films")]
        public List<string> films { get; set; }
        public List<string> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
