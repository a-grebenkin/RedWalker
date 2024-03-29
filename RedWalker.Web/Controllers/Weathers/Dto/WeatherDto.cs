﻿namespace RedWalker.Web.Controllers.Weathers.Dto;

public class WeatherDto
{
    public int Temperature { get; set; } 
    public double Precip { get; set; } //осадки мм
    public int Visibility { get; set; } //видимость км
    public int Windspeed { get; set; } //скорость ветра км/ч
    public int Cloudcover { get; set; } //облачность %
    public string WeatherCondition { get; set; }
}