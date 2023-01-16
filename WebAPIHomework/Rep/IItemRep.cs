using WebAPIHomework.Model;

namespace WebAPIHomework.Rep
{
    public interface IItemRep
    {
        Task<ItemResponse> GetItemAsync();
        Task<ItemResponse> CreateItemAsync(ItemRequest item);
    }
}
