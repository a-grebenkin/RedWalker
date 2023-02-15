using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RedWalker.Data.Accidents;

namespace RedWalker.Data.Items
{
    [Table("Items")]
    public class ItemDbModel
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double RLat { get; set; }
        public double RLon { get; set; }
        public List<AccidentDbModel> Accidents { get; set; }
    }
    
    
}