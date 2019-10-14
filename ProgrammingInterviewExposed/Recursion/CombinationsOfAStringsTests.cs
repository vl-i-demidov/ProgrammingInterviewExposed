using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace ProgrammingInterviewExposed.Recursion
{
    public class CombinationsOfAStringsTests
    {
        [Fact]
        public void CreateCombinationsRight()
        {
            var pr = new CombinationsOfAStrings("ABC");
            var combinations = pr.Combine();

            var expected = new[] { "A", "AB", "ABC", "AC", "B", "BC", "C" };
            Assert.Equal(expected.OrderBy(s => s), combinations.OrderBy(s => s));
        }

        [Fact]
        public void CreateCombinationsRight2()
        {
            var pr = new CombinationsOfAStrings2("ABC");
            var combinations = pr.Combine();

            var expected = new[] { "A", "AB", "ABC", "AC", "B", "BC", "C" };
            Assert.Equal(expected.OrderBy(s => s), combinations.OrderBy(s => s));
        }
    }
}
