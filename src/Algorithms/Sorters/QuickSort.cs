using System.Collections.Generic;


namespace AD
{
    public partial class QuickSort : Sorter
    {
        private static int CUTOFF = 3;

        public override void Sort(List<int> list)
        {
            int low = 0;
            int high = list.Count - 1;

            if (low + CUTOFF > high)
            {
                new InsertionSort().Sort(list);
            }
            else
            {
                //Find Median-of-three
                int middle = (low + high) / 2;
                if (list[middle] < (list[low]))
                    list.Swap<int>(middle, low);
                if (list[high] < list[low])
                    list.Swap<int>(low, high);
                if (list[high] < list[middle])
                    list.Swap<int>(high, middle);

                // Determine Pivot and set it to the end of the list
                list.Swap<int>(middle, high);
                int pivot = list[high];

                int i, j;
                for (i = low, j = high -1; ;)
                {
                    //Find first integer bigger than pivot
                    while (list[i] < pivot)
                        i++;
                    //Find first integer smaller than pivot
                    while (list[j] > pivot)
                        j--;
                    //Stop if i >= j
                    if (i >= j)
                        break;

                    //Swap values in array
                    list.Swap<int>(i, j);
                }
                //Restore Pivot
                list.Swap<int>(i, high);

                List<int> beforePivot = list.GetRange(low, i);
                List<int> afterPivot = list.GetRange(i + 1, list.Count - (i + 1));
                Sort(beforePivot);
                Sort(afterPivot);

                list.Clear();
                list.AddRange(beforePivot);
                list.Add(pivot);
                list.AddRange(afterPivot);
            }
        }
    }

    public static class Extensions
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
    }
}
