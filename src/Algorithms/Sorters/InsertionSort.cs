using System.Collections.Generic;


namespace AD
{
    public partial class InsertionSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            //Loop through list
            for(int p = 1; p < list.Count; p++)
            {
                //j = iterator through temp array
                //tmp = temporary int
                int tmp = list[p];
                int j = p;

                //j > 0
                //tmp.CompareTo(list[j-1]) < 0
                for(; j > 0 && tmp.CompareTo(list[j-1]) < 0; j--)
                {
                    list[j] = list[j - 1];
                }

                list[j] = tmp;
            }
        }
    }
}
