using System;

namespace WebApplication.Controllers.Accidents.Dto;

public class AccidentShortDto
{
    public int Id { get; set; }
    public int Wounded { get; set; } // раненых
    public int Death { get; set; } // погибших
    public DateTime DateTime { get; set; }
}