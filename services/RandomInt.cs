using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace swapi.Services{

    public class RandomTest{
        static int RandomNumber(){
            Random random = new Random(); return random.Next(1, 90);
    }
        
    }
}
