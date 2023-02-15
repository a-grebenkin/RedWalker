using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Items.Repositories;

namespace RedWalker.Core.Domains.Items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public Task<List<Item>> GetAllAsync()
        {
            return _itemRepository.GetAllAsync();
        }
    }
}