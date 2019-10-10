using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.Recursion
{
    public class BinarySearchTests
    {
        [Fact]
        public void SearchesRight()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4 };
            int[] array3 = { };

            Assert.Equal(2, BinarySearch.FindIndex(array, 3));
            Assert.Equal(2, BinarySearch.FindIndex(array2, 3));
            Assert.Equal(-1, BinarySearch.FindIndex(array, 7));
            Assert.Equal(-1, BinarySearch.FindIndex(array3, 3));
        }


        [Fact]
        public void SearchesRightNonRecursive()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4 };
            int[] array3 = { };

            Assert.Equal(2, BinarySearch.FindIndexNonRecursive(array, 3));
            Assert.Equal(2, BinarySearch.FindIndexNonRecursive(array2, 3));
            Assert.Equal(-1, BinarySearch.FindIndexNonRecursive(array, 7));
            Assert.Equal(-1, BinarySearch.FindIndexNonRecursive(array3, 3));
        }
    }
}
