using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Data.Accidents;
using RedWalker.Data.Directories;
using RedWalker.Data.Images;
using RedWalker.Data.Items;
using RedWalker.Data.Items.Repositories;

namespace RedWalker.Data
{
    public class RedWalkerContext: DbContext
    {
        public DbSet<ItemDbModel> Items { get; set; }
        public DbSet<LightingConditionDbModel> LightingConditions { get; set; }
        public DbSet<RoadWayConditionDbModel> RoadWayConditions { get; set; }
        public DbSet<SceneAccidentDbModel> SceneAccidents { get; set; }
        public DbSet<AccidentTypeDbModel> AccidentTypes { get; set; }
        public DbSet<ItemTypeDbModel> ItemTypes { get; set; }
        public DbSet<WeatherConditionDbModel> WeatherConditions { get; set; }
        public DbSet<AccidentDbModel> Accidents { get; set; }
        public DbSet<ImageDbModel> Images { get; set; }

        public RedWalkerContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}