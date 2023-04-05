using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Items.Services;
using WebApplication.Controllers.Accidents.Dto;
using WebApplication.Controllers.Items.Dto;

namespace RedWalker.Web.Controllers.Items
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var items =  await _itemService.GetAllAsync();
            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Type = item.Type,
                Lat = item.Lat,
                Lon = item.Lon,
                RLat = item.RLat,
                RLon = item.RLon,
                Wounded = item.Accidents.Sum(x=>x.Wounded),
                Death = item.Accidents.Sum(x=>x.Death),
                Accidents = item.Accidents.Select(accident => new AccidentShortDto
                {
                    Id = accident.Id,
                    Death = accident.Death,
                    Wounded = accident.Wounded,
                    DateTime = accident.DateTime
                }).ToList()
            });
        }
    }
}

