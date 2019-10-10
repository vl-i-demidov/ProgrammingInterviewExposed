using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class IntegerStringConversionsTests
    {
        [Fact]
        public void ConvertsStringToIntRight()
        {
            Assert.Equal(123, IntegerStringConversions.ConvertToInt("123"));
            Assert.Equal(-123, IntegerStringConversions.ConvertToInt("-123"));
        }

        [Fact]
        public void ConvertsIntToStringRight()
        {
            Assert.Equal("123", IntegerStringConversions.ConvertToString(123));
            Assert.Equal("-123", IntegerStringConversions.ConvertToString(-123));
        }

    }
}
