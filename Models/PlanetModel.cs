using System;
using System.Collections.Generic;
using System.Text;
using SolrNet.Attributes;

namespace swapi.Models
{
    public class PlanetModel
    {
        [SolrUniqueKey("planet_id")]
        public int Planet_Id { get; set; }
        [SolrField("name_s")]
        public string name { get; set;}
        [SolrField("rotation_period_i")]
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        [SolrField("climate_s")]
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set;}
        public string population { get; set; }
    }
}