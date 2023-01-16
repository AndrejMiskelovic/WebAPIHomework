using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPIHomework.Model;
using WebAPIHomework.Rep;
using static WebAPIHomework.Model.ItemResponseErrorEnum;

namespace WebAPIHomework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortingController : ControllerBase
    {
        private readonly IItemRep _itemRep;
        private readonly ILogger<SortingController> _logger;

        public SortingController(ILogger<SortingController> logger, IItemRep itemRep)
        {
            this._itemRep = itemRep;
            _logger = logger;
        }
        // GET: SortingController
        [HttpGet]
        public async Task<ActionResult<ItemResponse>> GetSortedNumbers()
        {
            var collection = await _itemRep.GetItemAsync();
            return Ok(collection);
        }

        // POST: SortingController/Create
        [HttpPost]
        public async Task<ActionResult<ItemResponse>> StoreNumbers([FromQuery] long[] collection)
        {            
            ItemRequest item = new ItemRequest();
            item.Array = collection;
            ItemResponse itemResponse = new ItemResponse();

            if (collection.Length == 0)
            {
                itemResponse.ItemResponseError = ItemResponseError.RequestIsEmpty;
                return BadRequest(itemResponse);
            }

            itemResponse  = await _itemRep.CreateItemAsync(item);
            return Ok(itemResponse);
        }
    }
}
