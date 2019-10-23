using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.GraphicsAndBitManipulation
{
    /*
      PROBLEM Write a function that determines the number of 1 bits in the binary
      representation of a given integer.
     */

    class NumberOfOnes
    {
        public static int GetOnBitsCount(int i)
        {
            int count = 0;

            bool isNegative = false;
            if (i < 0)
            {
                isNegative = true;
                i = i ^ -1;
            }

            while (i != 0)
            {
                if ((i & 1) == 1)
                {
                    count++;
                }
                i = i >> 1;
            }

            if (isNegative)
            {
                count = 32 - count;
            }

            return count;
        }


    }
}
