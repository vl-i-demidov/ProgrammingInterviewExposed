using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    /*
     PROBLEM Write two conversion routines. The first routine converts a string
     to a signed integer. You may assume that the string contains only digits and the
     minus character ('-'), that it is a properly formatted integer number, and that
     the number is within the range of an int type. The second routine converts a
     signed integer stored as an int back to a string.
     */
    class IntegerStringConversions
    {
        public static int ConvertToInt(string s)
        {
            var chars = s.ToCharArray();
            int sum = 0;

            for (int i = chars.Length - 1; i >= 0; i--)
            {
                var c = chars[i];

                if (c == '-')
                {
                    sum = sum * -1;
                }
                else
                {
                    int power = chars.Length - 1 - i;
                    sum = sum + GetCharDigit(c) * (int)Math.Pow(10, power);
                }
            }

            return sum;
        }


        public static string ConvertToString(int i)
        {
            var s = new StringBuilder();

            int mod = 0;
            int pow = 1;
            
            while (mod != i)
            {
                mod = (int)(i % Math.Pow(10, pow));
                int digit = (int)Math.Floor(Math.Abs(mod) / Math.Pow(10, pow - 1));
                s.Insert(0, GetDigitChar(digit));

                pow++;
            }

            if (i < 0)
            {
                s.Insert(0, '-');
            }

            return s.ToString();
        }

        const byte ZeroAscii = 48;

        private static char GetDigitChar(int i)
        {
            return (char)(ZeroAscii + i);
        }

        private static int GetCharDigit(char c)
        {
            return (byte)c - ZeroAscii;
        }

    }
}
