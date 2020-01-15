// using System;
// using System.Collections.Generic;
// using System.Text;
// using swapi.Models;
// using System.Net.Http;
// using Newtonsoft.Json;
// using System.Threading.Tasks;

// namespace swapi.Services
// {
//     public class SwapiPeople
//     {
//         public async Task<PersonModel> IndexSwapiPeople()
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = new Uri($"https://swapi.co/api/people/{IndexInts.SwapiPeopleInts()}");

//                 var response = await client.GetAsync(url);

//                 // string PeopleJson;
//                 // using (var content = response.Content)
//                 // {
//                 //     PeopleJson = await content.ReadAsStringAsync();
//                 // }
//                 return JsonConvert.DeserializeObject<PersonModel>(PeopleJson);
//             }
//         }
//     }
// }
