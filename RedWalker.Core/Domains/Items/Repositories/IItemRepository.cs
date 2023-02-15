using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Items.Repositories;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
}