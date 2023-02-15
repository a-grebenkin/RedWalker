using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedWalker.Data.Items;


namespace RedWalker.Data.Accidents
{
    [Table("Accidents")]
    public class AccidentDbModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public ItemDbModel Item { get; set; }
        public int Wounded { get; set; } // раненых
        public int Death { get; set; } // погибших
        public string Adddres { get; set; } //адрес 
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Type { get; set; } //вид происшествия
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public double Precip { get; set; } //осадки мм
        public int Visibility { get; set; } //видимость км
        public int Windspeed { get; set; } //скорость ветра км/ч
        public int Cloudcover { get; set; } //облачность %
        public int Lighting { get; set; } //освещение
        public int RoadWay { get; set; } //состояние дороги
        public int SceneAccident { get; set; } //место происшествия
        public int Weather { get; set; } //погода 
    }
    internal class ItemConfiguration : IEntityTypeConfiguration<AccidentDbModel>
    {
        public void Configure(EntityTypeBuilder<AccidentDbModel> builder)
        {
            builder.HasOne(it => it.Item)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.ItemId);
        }
    }
}