using System.Collections.Generic;
using WebApplication.Controllers.Accidents.Dto;

namespace WebApplication.Controllers.Items.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double RLat { get; set; }
        public double RLon { get; set; }
        public double Wounded { get; set; }
        public double Death { get; set; }
        public List<AccidentShortDto> Accidents { get; set; }
    }
}

