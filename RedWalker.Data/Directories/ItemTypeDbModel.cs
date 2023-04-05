using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RedWalker.Data.Items;

namespace RedWalker.Data.Directories;

[Table("ItemType")]
public class ItemTypeDbModel
{
    public int Id { get; set; }
    public string StringId { get; set; }
    public string Name{ get; set; }
    public List<ItemDbModel> Items { get; set; }
}