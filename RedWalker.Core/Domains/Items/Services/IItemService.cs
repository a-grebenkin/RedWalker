using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Paginates;

namespace RedWalker.Core.Domains.Items.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllAsync();
        PagedList<Item> GetPaginated(PaginateParametrs paginateParametrs);
        Task<List<Item>> GetForecastByLatLonRad(double lat, double lon, double radKm);
    }
}