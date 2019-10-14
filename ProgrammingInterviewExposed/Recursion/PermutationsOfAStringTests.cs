using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.Recursion
{
    public class PermutationsOfAStringTests
    {
        private readonly ITestOutputHelper _output;

        public PermutationsOfAStringTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void PermutatesStringRight()
        {
            var program = new PermutationsOfAString("abcd");

            var permutations = program.GetPermutations();

            _output.WriteLine(String.Join(" | ", permutations));

            var unique = new HashSet<string>(permutations);

            Assert.Equal(24, permutations.Count);
            Assert.Equal(24, unique.Count);
        }

    }
}
