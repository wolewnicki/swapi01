using System.Collections.Generic;
using swapi.Models;

// this is here to be able to return a list of people from swapi
public class RootObject<T>
{
    public List<T> results { get; set; }
    public int count { get; set; }
    public string next { get; set; }
    public object previous { get; set;}
}