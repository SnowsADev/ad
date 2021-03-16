using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AD
{
    public partial class MergeSort : Sorter
    {
        public override void Sort(List<int> list)
        {
            list = MergeSortAlgorithm(list);
        }
    
        private List<int> MergeSortAlgorithm(List<int> unsorted)
        {
            if (unsorted.Count <= 1) return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int center = unsorted.Count / 2;

            //Fill left
            for(int i = 0; i < center; i++)
            {
                left.Add(unsorted[i]);
            }
            //Fill right;
            for(int i = center; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = this.MergeSortAlgorithm(left); //Split left again
            right = this.MergeSortAlgorithm(right); //Split right again
            return Merge(left, right); //Merge them back up
         }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count > 0)
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    //Left <= Right -> Add Left to result
                    if(left[0] <= right[0])
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);
                    } else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                }
                else if(left.Count > 0)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
                else if(right.Count > 0)
                {
                    result.Add(right[0]);
                    right.Remove(right[0]);
                }
            }

            return result;
        }
    }

    
}
