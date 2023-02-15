using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Data.Accidents;
using RedWalker.Data.Items;
using RedWalker.Data.Items.Repositories;

namespace RedWalker.Data
{
    public class RedWalkerContext: DbContext
    {
        public DbSet<ItemDbModel> Items { get; set; }
        public DbSet<AccidentDbModel> Accidents { get; set; }
        
        public RedWalkerContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}