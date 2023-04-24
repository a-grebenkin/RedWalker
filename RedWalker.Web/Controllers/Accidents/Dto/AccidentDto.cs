using System;
namespace WebApplication.Controllers.Accidents.Dto
{
    public class AccidentDto
    {
        public int Id { get; set; }
        public int Wounded { get; set; } // раненых
        public int Death { get; set; } // погибших
        public string Adddres { get; set; } //адрес 
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string AccidentType { get; set; } //вид происшествия
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public double Precip { get; set; } //осадки мм
        public int Visibility { get; set; } //видимость км
        public int Windspeed { get; set; } //скорость ветра км/ч
        public int Cloudcover { get; set; } //облачность %
        public string Lighting { get; set; } //освещение
        public string RoadWay { get; set; } //состояние дороги
        public string SceneAccident { get; set; } //место происшествия
        public string Weather { get; set; } //погода 
      
    }
}

