namespace RedWalker.Data.Weathers.Models;

public class CurrentCondition
{
    public int temp_C { get; set; }
    public int windspeedKmph { get; set; }
    public double precipMM { get; set; }
    public int visibility { get; set; }
    public int cloudcover { get; set; }
}