using System.Collections.Generic;
using RedWalker.Core.Domains.Accidents;

namespace RedWalker.Core.Domains.Items
{
    public class Item
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double RLat { get; set; }
        public double RLon { get; set; }
        public List<Accident> Accidents { get; set; }
    }
}