using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace swapi.Services
{
    public class SwapiIndexer<T, U>
    {
        private readonly GetSwapiData<T> _getSwapiData;

        private readonly SolrInjector<U> _solrHandler;

        public SwapiIndexer(GetSwapiData<T> getSwapiData, SolrInjector<U> solrHandler)
        {
            _getSwapiData = getSwapiData;
            _solrHandler = solrHandler;
        }

        public async Task<ActionResult> ReturnCompleteSwapiList(string Uri)
        {
            int n = 1;

            T JsonArray = await _getSwapiData.ReturnData(Uri);
            var AllItems = new List<U>(JsonArray.results);

            while(JsonArray.next != null)
            {
                JsonArray = await _getSwapiData.ReturnData(JsonArray.next);
                JsonArray.results.ForEach(AllItems.Add);
            }

            foreach(U index in AllItems)
            {
                index.Uid = n++;
            }
            AllItems.ForEach(_solrHandler.AddToSolr);
            return OkResult();
        }
    }
}