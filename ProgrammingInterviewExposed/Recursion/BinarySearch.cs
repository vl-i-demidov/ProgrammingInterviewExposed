using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Recursion
{
    /*
      PROBLEM Implement a function to perform a binary search on a sorted array
      of integers to find the index of a given integer. Comment on the efficiency of this
      search, and compare it with other search methods.
     */

    class BinarySearch
    {
        public static int FindIndex(int[] array, int value)
        {
            if (array.Length == 0)
            {
                return -1;
            }
            return Find(array, 0, array.Length - 1, value);
        }

        private static int Find(int[] array, int startIndex, int endIndex, int value)
        {
            // xInt / yInt == Math.Floor(x.0 / y.0)

            int midIndex = (startIndex + endIndex) / 2;
            var midValue = array[midIndex];

            //base case

            if (midValue == value)
            {
                return midIndex;
            }

            if (startIndex == endIndex)
            {
                return -1;
            }

            //recursive case
            if (midValue < value)
            {
                return Find(array, midIndex + 1, endIndex, value);
            }
            return Find(array, startIndex, midIndex + 1, value);

        }

        public static int FindIndexNonRecursive(int[] array, int value)
        {
            int lower = 0;
            int upper = array.Length - 1;

            while (true)
            {
                int range = upper - lower;
                int center = lower + range / 2;

                if (range < 0)
                {
                    return -1;
                }

                if (array[center] == value)
                {
                    return center;
                }

                if (array[center] < value)
                {
                    lower = center + 1;
                }
                else
                {
                    upper = center - 1;
                }
            }
        }
    }
}
