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
    }
}
