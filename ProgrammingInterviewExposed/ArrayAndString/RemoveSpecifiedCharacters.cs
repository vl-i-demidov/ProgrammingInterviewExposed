using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    /*
      PROBLEM Write an efficient function that deletes characters from an ASCII
      string. Use the prototype
      string removeChars( string str, string remove );
      where any character existing in remove must be deleted from str. For example,
      given a str of "Battle of the Vowels: Hawaii vs. Grozny" and a remove of
      "aeiou", the function should transform str to “Bttl f th Vwls: Hw vs. Grzny”.
      Justify any design decisions you make, and discuss the efficiency of your solution.
     */

    class RemoveSpecifiedCharacters
    {
        //runtime O(n+m)
        //space O(n+m) (?)
        public static string RemoveChars(string str, string remove)
        {
            //don't respect surrogate chars for simplicity
            var removeCharsMap = new HashSet<char>();

            foreach (var ch in remove)
            {
                removeCharsMap.Add(ch);
            }

            var resultChars = new List<char>();

            foreach (var ch in str)
            {
                if (!removeCharsMap.Contains(ch))
                {
                    resultChars.Add(ch);
                }
            }
            return new string(resultChars.ToArray());
        }

        //here we use boolean array instead of map, because we know that the string is ASCII and, hence, 
        //there are less than 256 options
        //if it were any Unicode symbol, map would be more efficient
        public static string RemoveChars2(string str, string remove)
        {
            //don't respect surrogate chars for simplicity
            var removeCharsMap = new bool[Byte.MaxValue];

            foreach (var ch in remove)
            {
                removeCharsMap[(byte)ch] = true;
            }


            //not sure if this approach is better than building array from scratch
            //the pros is that we can use a static array
            //the cons is that we allocate same size array

            //in Java it makes probably more sense
            //because you cannot iterate through char array of string directly

            var resultChars = str.ToCharArray();
            int resultIndex = 0;

            for (int srcIndex = 0; srcIndex < resultChars.Length; srcIndex++)
            {
                if (!removeCharsMap[(byte)resultChars[srcIndex]])
                {
                    resultChars[resultIndex++] = resultChars[srcIndex];
                }
            }

            return new string(resultChars, 0, resultIndex);
        }
    }
}
