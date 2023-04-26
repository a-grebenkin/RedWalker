using System.Collections.Generic;

namespace RedWalker.Data.Weathers.Models;

public class Data
{
    public List<CurrentCondition> current_condition { get; set; }
    public List<Weather> weather { get; set; }
}