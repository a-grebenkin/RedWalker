using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Items.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllAsync();
    }
}