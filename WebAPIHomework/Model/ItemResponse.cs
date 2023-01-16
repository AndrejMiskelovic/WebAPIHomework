using static WebAPIHomework.Model.ItemResponseErrorEnum;

namespace WebAPIHomework.Model
{
    public class ItemResponse
    {
        public long[] SortedArray { get; set; }
        public List<SortTimeInTicks> SortTimeInTicks { get; set; }
        public ItemResponseError? ItemResponseError { get; set; } 

    }
}
