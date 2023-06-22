using System.Collections.Generic;

namespace RedWalker.Data.Weathers.Models;

public class Weather
{
    public List<Astronomy> astronomy { get; set; }
    public string date { get; set; }
}