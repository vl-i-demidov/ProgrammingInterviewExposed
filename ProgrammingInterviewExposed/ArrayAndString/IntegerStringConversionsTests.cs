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
            Assert.Equal(12030, IntegerStringConversions.ConvertToInt("12030"));
            Assert.Equal(-12030, IntegerStringConversions.ConvertToInt("-12030"));
        }

        [Fact]
        public void ConvertsIntToStringRight()
        {
            Assert.Equal("12030", IntegerStringConversions.ConvertToString(12030));
            Assert.Equal("-12030", IntegerStringConversions.ConvertToString(-12030));
        }

        [Fact]
        public void ConvertsStringToIntRight2()
        {
            Assert.Equal(12030, IntegerStringConversions.ConvertToInt2("12030"));
            Assert.Equal(-12030, IntegerStringConversions.ConvertToInt2("-12030"));
        }

        [Fact]
        public void ConvertsIntToStringRight2()
        {
            Assert.Equal("12030", IntegerStringConversions.ConvertToString2(12030));
            Assert.Equal("-12030", IntegerStringConversions.ConvertToString2(-12030));
        }
    }
}
