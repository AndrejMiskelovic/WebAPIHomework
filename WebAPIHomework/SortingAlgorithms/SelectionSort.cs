namespace WebAPIHomework.SortingAlgorithms
{
    public class SelectionSort : ISortingAlgorithm
    {
        public long[] Sort(long[] input)
        {
            long[] tempArray = new long[input.Length];
            input.CopyTo(tempArray, 0);

            for (int i = 0; i < tempArray.Length - 1; i++)
            {
                var smallest = i;
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    if (tempArray[j] < tempArray[smallest])
                    {
                        smallest = j;
                    }
                }
                if (smallest != i)
                {
                    var temp = tempArray[smallest];
                    tempArray[smallest] = tempArray[i];
                    tempArray[i] = temp;
                }
            }
            return tempArray;
        }
    }
}
