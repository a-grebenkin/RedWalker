using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedWalker.Data.Accidents;
using RedWalker.Data.Directories;

namespace RedWalker.Data.Items
{
    [Table("Item")]
    public class ItemDbModel
    {
        public int Id { get; set; }
        [Column ("Type")]
        public int TypeItemId { get; set; }
        public ItemTypeDbModel TypeItem { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public double RLat { get; set; }
        public double RLon { get; set; }
        public List<AccidentDbModel> Accidents { get; set; }
    }

    internal class ItemConfiguration : IEntityTypeConfiguration<ItemDbModel>
    {
        public void Configure(EntityTypeBuilder<ItemDbModel> builder)
        {
            builder.HasOne(it => it.TypeItem)
                .WithMany(it => it.Items)
                .HasForeignKey(it => it.TypeItemId);
        }
    }

}