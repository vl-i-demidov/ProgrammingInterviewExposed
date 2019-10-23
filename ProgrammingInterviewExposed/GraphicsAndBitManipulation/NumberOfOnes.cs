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

        public static int GetOnBitsCount2(int i)
        {
            int count = 0;

            //in case i is negative just read it as unsigned
            //this way we save all the bits in their positions
            uint ui = (uint)i;

            while (ui != 0)
            {
                if ((ui & 1) == 1)
                {
                    count++;
                }
                ui = ui >> 1;
            }

            return count;
        }

        //advanced solution
        //based on the fact that i-1 flips all bits from 0 to lowest 1 
        public static int GetOnBitsCount3(int i)
        {
            int count = 0;

            //in case i is negative just read it as unsigned
            //this way we save all the bits in their positions
            uint ui = (uint)i;

            while (ui != 0)
            {
                ui = ui & (ui - 1);
                count++;
            }

            return count;
        }


    }
}
