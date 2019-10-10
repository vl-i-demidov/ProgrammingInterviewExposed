using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class ReverseWordsTests
    {
        const string Sentence = "Do or do not, there is no try.";
        const string ExpectedResult = "try. no is there not, do or Do";

        [Fact]
        public void ReversesRight()
        {
            Assert.Equal(ExpectedResult, ReverseWords.Reverse(Sentence));
        }

        [Fact]
        public void ReversesRightGeneral()
        {
            Assert.Equal(ExpectedResult, ReverseWords.ReverseGeneral(Sentence));
        }

        [Fact]
        public void ReversesRight2()
        {
            Assert.Equal(ExpectedResult, ReverseWords.Reverse2(Sentence));
        }

        [Fact]
        public void ReversesRight3()
        {
            Assert.Equal(ExpectedResult, ReverseWords.Reverse3(Sentence));
        }
    }
}
