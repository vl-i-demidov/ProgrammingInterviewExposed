using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Sorting
{
    /*
      PROBLEM You have an array of objects, each of which represents an employee:
       public class Employee {
           public String extension;
           public String givenname;
           public String surname;
       }
      Using a standard library sorting routine, sort the array so it is ordered alphabetically
      by surname and then by given name as in a company phone book.
     */

    class MultiKeySort
    {
        private static GivenNameComparer _givenNameComparer = new GivenNameComparer();

        //O(n*log(n)) + O(n) + O(l*k*log(k)) 
        //(l - count of same given name groups, k - average count of items in the group)
        public static void Sort(Employee[] data)
        {
            Array.Sort(data, SurnameComparison);

            for (int i = 0; i < data.Length - 1; i++)
            {
                int start = i;
                int end = i + 1;

                while (end < data.Length && SurnameComparison(data[start], data[end]) == 0)
                {
                    end++;
                }

                if (end - start > 1)
                {
                    Array.Sort(data, start, end - start, _givenNameComparer);
                    i = end - 1;
                }
            }
        }

        private static int SurnameComparison(Employee a, Employee b)
        {
            return a.Surname.CompareTo(b.Surname);
        }

        private class GivenNameComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.GivenName.CompareTo(y.GivenName);
            }
        }
    }

    class MultiKeySort2
    {
        private static Comparer _comparer = new Comparer();

        //O(n*log(n)) + O(n) + O(l*k*log(k)) 
        //(l - count of same given name groups, k - average count of items in the group)
        public static void Sort(Employee[] data)
        {
            Array.Sort(data, _comparer);
        }

        private static int SurnameComparison(Employee a, Employee b)
        {
            return a.Surname.CompareTo(b.Surname);
        }

        private class Comparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return $"{x.Surname}{x.GivenName}".CompareTo($"{y.Surname}{y.GivenName}");
            }
        }
    }

    class Employee
    {
        public string Extension { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
    }
}
