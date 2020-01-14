using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace swapi.Services{

    public static class RandomTest
    {
        public static int RandomNumber()
        {
            var random = new Random();
            var result = random.Next(1, 89);
            
            return result;
        }
        public static int RandomPlanet()
        {
            var randomPlanet = new Random();
            var planetResult = randomPlanet.Next(1, 62);

            return planetResult;
        }
    }
}
