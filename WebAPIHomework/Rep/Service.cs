using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using WebAPIHomework.Model;
using WebAPIHomework.SortingAlgorithms;
using static WebAPIHomework.Model.ItemResponseErrorEnum;

namespace WebAPIHomework.Rep
{
    public class Service : IItemRep
    {
        InteractionsWithFile fileManipulation;
        public Service(InteractionsWithFile interactionsWithFile)
        {
            fileManipulation = interactionsWithFile;
        }
        public async Task<ItemResponse> GetItemAsync()
        {
            var sortedNumbers = await fileManipulation.ReadData();
            var json = JsonConvert.SerializeObject(sortedNumbers);
            ItemResponse item = new ItemResponse();
            item = JsonConvert.DeserializeObject<ItemResponse>(json);
            return item;
        }
        public async Task<ItemResponse> CreateItemAsync(ItemRequest request)
        {
            Stopwatch stopwatch = new Stopwatch();

            var response = new ItemResponse();
            response.SortTimeInTicks = new List<SortTimeInTicks>();

            bool canBeStored = false;
            canBeStored = request.Array.Min() < 0 && request.Array.Max() > 10;
            if (canBeStored)
            {
                response.ItemResponseError = ItemResponseError.NumbersOutOfRange;
                return response;
            }

            var list = new List<ISortingAlgorithm>
            {
                new BubbleSort(),
                new SelectionSort(),
                new SomethingSort(),
            };

            long[] sortedArray = new long[request.Array.Length];

            foreach (var algorithm in list)
            {
                stopwatch.Start();
                sortedArray = algorithm.Sort(request.Array);
                stopwatch.Stop();

                response.SortTimeInTicks.Add(new SortTimeInTicks
                {
                    time = stopwatch.ElapsedTicks,
                    Algorithm = algorithm.ToString().Split('.').Last(),
                });

            }
            response.SortedArray = sortedArray;
            await fileManipulation.WriteData(response);

            return response;
        }
    }
}
