using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class UTF8StringValidationTests
    {
        [Fact]
        public void StringValidatedRight()
        {
            Assert.True(UTF8StringValidation.IsValid(GetValidString()));
            Assert.False(UTF8StringValidation.IsValid(GetInvalidString()));
        }

        [Fact]
        public void StringValidatedRight2()
        {
            Assert.True(UTF8StringValidation.IsValid2(GetValidString()));
            Assert.False(UTF8StringValidation.IsValid2(GetInvalidString()));
        }

        private static byte[] GetValidString()
        {
            var raw = "00000000 11100000_10000000_10000000 11110000_10000000_10000000_10000000 11000000_10000000" +
                      "11100000_10000000_10000000 11100000_10000000_10000000 00000000";
            return ByteArrayFromRaw(raw);
        }

        private static byte[] GetInvalidString()
        {
            var raw = "00000000 11100000_10000000_10000000 11100000_10000000_10000000_10000000 1100000_10000000" +
                      "11100000_10000000_10000000 11100000_10000000_10000000 00000000";
            return ByteArrayFromRaw(raw);
        }

        private static byte[] ByteArrayFromRaw(string raw)
        {
            List<bool> data = new List<bool>();
            foreach (var ch in raw)
            {
                if (Char.IsDigit(ch))
                {
                    data.Add(ch == '1');
                }
            }
            
            return BitArrayToByteArray(new BitArray(data.ToArray()));
        }


        private static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

    }
}
