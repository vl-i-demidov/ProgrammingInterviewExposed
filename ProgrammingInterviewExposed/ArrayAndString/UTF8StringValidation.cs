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


    }
}
