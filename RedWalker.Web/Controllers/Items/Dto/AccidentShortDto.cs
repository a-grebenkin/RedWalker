using System;

namespace RedWalker.Web.Controllers.Items.Dto;

public class AccidentShortDto
{
    public int Id { get; set; }
    public int Wounded { get; set; } // раненых
    public int Death { get; set; } // погибших
    public DateTime DateTime { get; set; }
    public int Temperature { get; set; }
    public double Precip { get; set; } //осадки мм
    public int Visibility { get; set; } //видимость км
    public int Windspeed { get; set; } //скорость ветра км/ч
    public int Cloudcover { get; set; } //облачность %
    public string AccidentType { get; set; } //вид происшествия
    public string Lighting { get; set; } //освещение
    public string RoadWay { get; set; } //состояние дороги
    public string Weather { get; set; } //погода 
}