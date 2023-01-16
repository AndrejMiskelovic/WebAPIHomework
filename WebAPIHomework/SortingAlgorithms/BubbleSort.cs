namespace WebAPIHomework.SortingAlgorithms
{
    public class BubbleSort : ISortingAlgorithm
    {
        public long[] Sort(long[] input)
        {
            long[] tempArray = new long[input.Length];
            input.CopyTo(tempArray, 0);

            bool swapRequired;
            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                swapRequired = false;
                for (int j = 0; j < tempArray.Length - i - 1; j++)
                    if (tempArray[j] > tempArray[j + 1])
                    {
                        var temp = tempArray[j];
                        tempArray[j] = tempArray[j + 1];
                        tempArray[j + 1] = temp;
                        swapRequired = true;
                    }
                if (swapRequired == false)
                    break;
            }
            return tempArray;
        }
    }
}
