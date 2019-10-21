using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Sorting
{
    /*
      PROBLEM Implement an efficient, in-place version of the quicksort algorithm.
     */
    class OptimizedQuicksort
    {
        public static void Sort(int[] data)
        {
            Sort(data, 0, data.Length - 1);
        }

        //to make algorithm in-place, we use swapping
        //after calculating pivot value, all values to the left of pivot, that are greater than pivot,
        //swapped with values to the right of pivot, that are less than pivot   
        private static void Sort(int[] data, int left, int right)
        {
            int pivotValue = data[(left + right) / 2];
            int i = left, j = right;

            while (i < j)
            {
                // Find leftmost value greater than or equal to the pivot
                while (data[i] < pivotValue) i++;

                // Find rightmost value less than or equal to the pivot.
                while (data[j] > pivotValue) j--;

                if (i <= j)
                {
                    Swap(data, i, j);
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                Sort(data, left, j);
            }

            if (i > right)
            {
                Sort(data, i, right);
            }
        }

        private static void Swap(int[] data, int srcInd, int destInd)
        {
            var temp = data[srcInd];
            data[srcInd] = temp;
            data[destInd] = temp;
        }

    }
}
