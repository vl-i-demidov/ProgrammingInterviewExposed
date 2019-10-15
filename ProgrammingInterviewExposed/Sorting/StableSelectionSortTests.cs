using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.Sorting
{
    public class StableSelectionSortTests
    {
        [Fact]
        public void SortsNotStableRight()
        {
            var nonSorted = new[] { 7, 5, 1, 2, 8, 9, 3, 0, 4, 6 };
            var sorted = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            NonStableSelectionSort.Sort(nonSorted);

            Assert.Equal(sorted, nonSorted);
        }

        [Fact]
        public void SortsStableRight()
        {
            var nonSorted = new[] { 7, 5, 1, 2, 8, 9, 3, 0, 4, 6 };
            var sorted = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            StableSelectionSort<int>.Sort(nonSorted);

            Assert.Equal(sorted, nonSorted);
        }
    }
}
