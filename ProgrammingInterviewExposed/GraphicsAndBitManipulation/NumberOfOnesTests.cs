using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.GraphicsAndBitManipulation
{
    public class NumberOfOnesTests
    {
        [Fact]
        public void CalculatesNumberRight()
        {
            Assert.Equal(0, NumberOfOnes.GetOnBitsCount(0));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount(1));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount(2));
            Assert.Equal(2, NumberOfOnes.GetOnBitsCount(3));

            Assert.Equal(1, NumberOfOnes.GetOnBitsCount(8));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount(1024));
            Assert.Equal(8, NumberOfOnes.GetOnBitsCount(2019));

            Assert.Equal(25, NumberOfOnes.GetOnBitsCount(-2019));


        }
    }
}
