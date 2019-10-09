using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class ReverseWordsTests
    {
        [Fact]
        public void ReversesRight()
        {
            var sentence = "Do or do not, there is no try.";
            var expectedResult = "try. no is there not, do or Do";

            Assert.Equal(expectedResult, ReverseWords.Reverse(sentence));
        }

    }
}
