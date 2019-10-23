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

        [Fact]
        public void CalculatesNumberRight2()
        {
            Assert.Equal(0, NumberOfOnes.GetOnBitsCount2(0));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount2(1));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount2(2));
            Assert.Equal(2, NumberOfOnes.GetOnBitsCount2(3));

            Assert.Equal(1, NumberOfOnes.GetOnBitsCount2(8));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount2(1024));
            Assert.Equal(8, NumberOfOnes.GetOnBitsCount2(2019));

            Assert.Equal(25, NumberOfOnes.GetOnBitsCount2(-2019));
        }

        [Fact]
        public void CalculatesNumberRight3()
        {
            Assert.Equal(0, NumberOfOnes.GetOnBitsCount3(0));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount3(1));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount3(2));
            Assert.Equal(2, NumberOfOnes.GetOnBitsCount3(3));

            Assert.Equal(1, NumberOfOnes.GetOnBitsCount3(8));
            Assert.Equal(1, NumberOfOnes.GetOnBitsCount3(1024));
            Assert.Equal(8, NumberOfOnes.GetOnBitsCount3(2019));

            Assert.Equal(25, NumberOfOnes.GetOnBitsCount3(-2019));
        }
    }
}
