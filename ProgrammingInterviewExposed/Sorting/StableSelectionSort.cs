using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Sorting
{
    /*
     PROBLEM Implement a stable version of the selection sort algorithm.
     */

    //this solution is not the final one in the book
    //but the final one is hard to implement in C#
    class StableSelectionSort<T>
    {
        public static void Sort(T[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                Insert(data, i, FindMinIndex(data, i));
            }
        }

        private static void Insert(T[] data, int start, int minIndex)
        {
            if (start < minIndex)
            {
                var temp = data[minIndex];
                Array.Copy(data, start, data, start + 1, minIndex - start);
                data[start] = temp;
            }
        }

        private static int FindMinIndex(T[] data, int minValIndex)
        {
            int minIndex = minValIndex;
            for (int i = minValIndex + 1; i < data.Length; i++)
            {
                if (Compare(data[i], data[minIndex]) == -1)
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private static T GetMinimum(LinkedList<T> data, LinkedListNode<T> node)
        {
            var minNode = node;
            var next = node.Next;

            while (next != null)
            {
                if (Compare(next.Value, minNode.Value) == -1)
                {
                    minNode = next;
                }
                next = next.Next;
            }

            data.Remove(minNode);

            return minNode.Value;
        }

        private static int Compare(T a, T b)
        {
            var ca = (IComparable<T>)a;
            return ca.CompareTo(b);
        }
    }

    class NonStableSelectionSort
    {
        public static void Sort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                Swap(data, i, FindMinElement(data, i));
            }
        }

        private static void Swap(int[] data, int srcInd, int destInd)
        {
            if (srcInd != destInd)
            {
                var tmp = data[srcInd];
                data[srcInd] = data[destInd];
                data[destInd] = tmp;
            }
        }

        private static int FindMinElement(int[] data, int minValIndex)
        {
            int minValue = data[minValIndex];
            int minIndex = minValIndex;
            for (int i = minValIndex + 1; i < data.Length; i++)
            {
                if (data[i] < minValue)
                {
                    minValue = data[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

    }
}
