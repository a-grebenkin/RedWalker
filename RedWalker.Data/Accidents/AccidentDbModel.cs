using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedWalker.Data.Directories;
using RedWalker.Data.Items;


namespace RedWalker.Data.Accidents
{
    [Table("Accident")]
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
        [Column("TypeId")]
        public int AccidentTypeId { get; set; } //вид происшествия
        public AccidentTypeDbModel AccidentType { get; set; } //вид происшествия
        public DateTime DateTime { get; set; }
        public int Temperature { get; set; }
        public double Precip { get; set; } //осадки мм
        public int Visibility { get; set; } //видимость км
        public int Windspeed { get; set; } //скорость ветра км/ч
        public int Cloudcover { get; set; } //облачность %
        [Column("LightingId")]
        public int LightingConditionDbModelId { get; set; } //освещение
        public LightingConditionDbModel Lighting { get; set; } //освещение
        [Column("RoadWayId")]
        public int RoadWayConditionDbModelId { get; set; } //состояние дороги
        public RoadWayConditionDbModel RoadWay { get; set; } //состояние дороги
        [Column("SceneAccidentId")]
        public int SceneAccidentDbModelId { get; set; } //место происшествия
        public SceneAccidentDbModel SceneAccident { get; set; } //место происшествия
        [Column("WeatherId")]
        public int WeatherConditionDbModelId { get; set; } //погода 
        public WeatherConditionDbModel WeatherCondition { get; set; } //погода 
        
    }
    internal class ItemConfiguration : IEntityTypeConfiguration<AccidentDbModel>
    {
        public void Configure(EntityTypeBuilder<AccidentDbModel> builder)
        {
            builder.HasOne(it => it.Item)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.ItemId);
            
            builder.HasOne(it => it.Lighting)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.LightingConditionDbModelId);
            
            builder.HasOne(it => it.RoadWay)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.RoadWayConditionDbModelId);
            
            builder.HasOne(it => it.SceneAccident)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.SceneAccidentDbModelId);
            
            /*builder.HasOne(it => it.AccidentType)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.AccidentTypeId);
            */
            builder.HasOne(it => it.WeatherCondition)
                .WithMany(it => it.Accidents)
                .HasForeignKey(it => it.WeatherConditionDbModelId);
        }
    }
}