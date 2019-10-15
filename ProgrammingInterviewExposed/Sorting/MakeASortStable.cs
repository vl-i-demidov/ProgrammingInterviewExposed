using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Sorting
{
    /*
      PROBLEM You are working on a platform that has a very fast, hardwareaccelerated
      sort routine. The routine, shakySort(), is not stable, but you need
      to perform a fast, stable sort. Write code that uses shakySort() to perform a
      stable sort.
     */

    class MakeASortStable
    {
        public static void Sort(Item[] data)
        {
            //assign sequence value to each item and use it dring comparison when values are equal
            //hence shakySort keeps order of equal values and becomes stable
            for (int i = 0; i < data.Length; i++)
            {
                data[i].Sequence = i;
            }

            ShakySort(data);
        }

        private static void ShakySort(Item[] data)
        {
            Array.Sort(data, new ItemComparator());
        }

        class ItemComparator : Comparer<Item>
        {
            public override int Compare(Item x, Item y)
            {
                var res = x.Value.CompareTo(y.Value);
                if (res == 0)
                {
                    res = x.Sequence.CompareTo(y.Sequence);
                }
                return res;
            }
        }
    }

    class Item
    {
        public int Value { get; set; }
        public int Sequence { get; set; }
    }
}
