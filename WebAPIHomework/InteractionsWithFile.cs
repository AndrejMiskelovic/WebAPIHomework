using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebAPIHomework.Model;
using static WebAPIHomework.Model.ItemResponseErrorEnum;

namespace WebAPIHomework
{
    public class InteractionsWithFile
    {
        private string _dataFile = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/data.json";
        public async Task WriteData(ItemResponse item) 
        {
            try
            {
                var itemJson = JsonConvert.SerializeObject(item);
                await File.WriteAllTextAsync(_dataFile, itemJson);
            }
            catch (IOException)
            {
                item.ItemResponseError = ItemResponseError.CouldNotOpenFile;
            }
            catch (Exception)
            {
                item.ItemResponseError = ItemResponseError.ServiceError;
            }

        }
        public async Task<ItemResponse> ReadData()
        {
            var item = new ItemResponse();
            if (!File.Exists(_dataFile))
            {
                item.ItemResponseError = ItemResponseError.FileDoesNotExist;
                return item;
            }

            if (new FileInfo(_dataFile).Length == 0)
            {
                item.ItemResponseError = ItemResponseError.FileIsEmpty;
                return item;
            }

            try
            {
                var json = await File.ReadAllTextAsync(_dataFile);
                item = JsonConvert.DeserializeObject<ItemResponse>(json);

            }
            catch (IOException)
            {
                item.ItemResponseError = ItemResponseError.CouldNotOpenFile;
            }
            catch (Exception)
            {
                item.ItemResponseError = ItemResponseError.ServiceError;
            }
            return item;
        }
    }

}
