using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    /*
     PROBLEM A valid UTF-8 string may contain only the following four bit
     patterns:
         0xxxxxxx
         110xxxxx 10xxxxxx
         1110xxxx 10xxxxxx 10xxxxxx
         11110xxx 10xxxxxx 10xxxxxx 10xxxxxx
     Write a function to determine whether a string meets this necessary (but not sufficient)
     criterion for UTF-8 validity.
     */

    class UTF8StringValidation
    {
        public static bool IsValid(byte[] str)
        {
            var ba = new BitArray(str);

            int pos = 0;

            bool checkTail = false;
            int tailsRemained = 0;

            while (pos < ba.Length)
            {
                if (checkTail)
                {
                    if (ba[pos] && !ba[pos + 1])
                    {
                        tailsRemained--;
                        if (tailsRemained == 0)
                        {
                            checkTail = false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    int onCount = 0;
                    int i = pos;

                    while (ba[i] && onCount < 5)
                    {
                        onCount++;
                        i++;
                    }

                    if (onCount == 0)
                    {
                        //do nothing
                    }
                    else if (onCount >= 2 && onCount <= 4)
                    {
                        checkTail = true;
                        tailsRemained = onCount - 1;
                    }
                    else
                    {
                        return false;
                    }
                }
                pos += 8;
            }

            return true;
        }

        //a more pure and simpler way
        public static bool IsValid2(byte[] str)
        {
            int pos = 0;
            int trailingRemained = 0;

            while (pos < str.Length)
            {
                var b = str[pos];

                if (trailingRemained > 0)
                {
                    if (!IsTrailing(b))
                    {
                        return false;
                    }
                    trailingRemained--;
                }
                else
                {
                    if (IsLeading1(b))
                    {

                    }
                    else if (IsLeading2(b))
                    {
                        trailingRemained = 1;
                    }
                    else if (IsLeading3(b))
                    {
                        trailingRemained = 2;
                    }
                    else if (IsLeading4(b))
                    {
                        trailingRemained = 3;
                    }
                    else
                    {
                        return false;
                    }
                }

                pos++;
            }

            return true;
        }


        private static bool IsTrailing(byte b)
        {
            //construct a value called a mask where the bits you are
            //interested in have a value of 1 and all other bits have values of 0.Combining the mask with the
            //byte to be interrogated using the & operator zeros out everything except your bits of interest.

            //10xxxxxx
            const byte mask = 0b11000000;
            const byte pattern = 0b10000000;

            return (b & mask) == pattern;
        }

        private static bool IsLeading1(byte b)
        {
            //0xxxxxxx
            const byte mask = 0b10000000;
            return (b & mask) == 0;
        }

        private static bool IsLeading2(byte b)
        {
            //110xxxxx
            const byte mask = 0b11100000;
            return (b & mask) == 0b11000000;
        }

        private static bool IsLeading3(byte b)
        {
            //1110xxxx
            const byte mask = 0b11110000;
            return (b & mask) == 0b11100000;
        }

        private static bool IsLeading4(byte b)
        {
            //11110xxx
            const byte mask = 0b11111000;
            return (b & mask) == 0b11110000;
        }
    }
}
