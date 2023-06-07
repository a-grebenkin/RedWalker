using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Paginates;

namespace RedWalker.Core.Domains.Items.Repositories;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    PagedList<Item> GetPaginated(PaginateParametrs paginateParametrs);
}