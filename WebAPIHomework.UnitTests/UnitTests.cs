using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebAPIHomework.Controllers;
using WebAPIHomework.Model;
using WebAPIHomework.Rep;
using WebAPIHomework.SortingAlgorithms;
using Xunit;
using static WebAPIHomework.Model.ItemResponseErrorEnum;

namespace WebAPIHomework.UnitTests
{
    public class UnitTests
    {
        private readonly Mock<SortingController> _sortingController = new();
        private readonly Mock<IItemRep> _itemRep = new();
        private readonly Mock<ILogger<SortingController>> _logger = new();

        [Fact]
        public void BubbleSortTest()
        {
            var algo = new BubbleSort();

            var input = new long[] { 2, 5, 3, 1, 4 };
            var expected = new long[] { 1, 2, 3, 4, 5 };

            var result = algo.Sort(input);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void SelectionSort()
        {
            var algo = new SelectionSort();

            var input = new long[] { 2, 5, 3, 1, 4 };
            var expected = new long[] { 1, 2, 3, 4, 5 };

            var result = algo.Sort(input);

            Assert.Equal(expected, result);
        }
        [Fact]
        public void SomethingSort()
        {
            var algo = new SomethingSort();

            var input = new long[] { 2, 5, 3, 1, 4 };
            var expected = new long[] { 1, 2, 3, 4, 5 };

            var result = algo.Sort(input);

            Assert.Equal(expected, result);
        }
        [Fact]
        public async void CreteAndGetSortedArray()
        {
            var input = new long[] { 2, 5, 3, 1, 4 };
            var expected = new long[] { 1, 2, 3, 4, 5 };
            ItemRequest itemRequest = new ItemRequest();
            itemRequest.Array = input;
            InteractionsWithFile interactionsWithFile = new InteractionsWithFile();
            var controller = new Service(interactionsWithFile);

            var res =  await controller.CreateItemAsync(itemRequest);

            var result = await controller.GetItemAsync();

            Assert.Equal(result.SortedArray, expected);
        }
        //private int[] CreateRandonArray() 
        //{
        //    Random randNum = new Random();
        //    randNum.Next(0, 10);
        //    int[] array = Enumerable
        //        .Repeat(0, 5)
        //        .Select(i => randNum.Next(0, randNum.Next(0, 10)))
        //        .ToArray();
        //    return array;
        //}
    }
}