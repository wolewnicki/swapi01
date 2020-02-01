using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using swapi.Models;

namespace swapi.Services
{
    public class SwapiIndexer<T> where T : IBaseSwapiModel
    {
        private readonly GetData<T> _getSwapiData;

        private readonly SolrInjector<T> _solrHandler;

        public SwapiIndexer(GetData<T> getSwapiData, SolrInjector<T> solrHandler)
        {
            _getSwapiData = getSwapiData;
            _solrHandler = solrHandler;
        }

        public async Task<List<T>> ReturnCompleteSwapiList(string Tri)
        {
            int n = 1;

            RootObject<T> JsonArray = await _getSwapiData.ReturnData(Tri);
            var AllItems = new List<T>(JsonArray.results);

            while(JsonArray.next != null)
            {
                JsonArray = await _getSwapiData.ReturnData(JsonArray.next);
                JsonArray.results.ForEach(AllItems.Add);
            }

            foreach(T index in AllItems)
            {
                index.TempId = n++;
            }
            AllItems.ForEach(_solrHandler.AddToSolr);
            return AllItems; 
        }
    }
}