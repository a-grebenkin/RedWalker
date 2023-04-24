using System;
using RedWalker.Core.Domains.Directories;

namespace RedWalker.Core.Domains.Accidents
{
    public class Accident
    {
        public int Id { get; set; }
        public int Wounded { get; set; } // раненых
        public int Death { get; set; } // погибших
        public string Adddres { get; set; } //адрес 
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Directory TypeDirectory { get; set; } //вид происшествия
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public double Precip { get; set; } //осадки мм
        public int Visibility { get; set; } //видимость км
        public int Windspeed { get; set; } //скорость ветра км/ч
        public int Cloudcover { get; set; } //облачность %
        public Directory LightingDirectory { get; set; } //освещение
        public Directory RoadWayDirectory { get; set; } //состояние дороги
        public Directory SceneAccidentDirectory { get; set; } //место происшествия
        public Directory WeatherDirectory { get; set; } //погода 
        public bool DarkTime { get; set; } //флаг темное время суток
    }
}