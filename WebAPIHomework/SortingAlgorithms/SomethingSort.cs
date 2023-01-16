namespace WebAPIHomework.SortingAlgorithms
{
    public class SomethingSort : ISortingAlgorithm
    {
        /// <summary>
        /// idk what sort it is, just was having fun
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public long[] Sort(long[] input)
        {
            long[] tempArray = new long[input.Length];
            input.CopyTo(tempArray, 0);

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = 0; j < tempArray.Length; j++)
                {
                    if (tempArray[i] < tempArray[j])
                    {
                        var temp = tempArray[j];
                        tempArray[j] = tempArray[i];
                        tempArray[i] = temp;
                    }
                }
            }
            return tempArray;
        }
    }
}
