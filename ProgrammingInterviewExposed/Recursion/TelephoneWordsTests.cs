using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.Recursion
{
    public class TelephoneWordsTests
    {
        private readonly ITestOutputHelper _output;


        public TelephoneWordsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FindWordsRight()
        {
            var program = new TelephoneWords(new[] {  2, 3, 4 });
            var result = program.Find();

            _output.WriteLine(String.Join(" | ", result));

            Assert.Equal(27, result.Count);
        }
    }
}
