using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    /*
     PROBLEM Write an efficient function to find the first nonrepeated character in a
     string. For instance, the first nonrepeated character in “total” is 'o' and the first
     nonrepeated character in “teeter” is 'r'. Discuss the efficiency of your algorithm.
     */

    class FirstNonrepeatedCharacter
    {
        //runtime O(2n) = O(n)
        //space O(n)
        public char FindNaive(string word)
        {
            var charMap = new Dictionary<char, int>();
            foreach (var ch in word)
            {
                if (!charMap.ContainsKey(ch))
                {
                    charMap.Add(ch, 0);
                }

                charMap[ch] = charMap[ch] + 1;
            }

            foreach (var chCount in charMap)
            {
                if (chCount.Value == 1)
                {
                    return chCount.Key;
                }
            }

            return Char.MinValue;
        }

        //here we respect surrogates - unicode symbols that do not fit into 2-byte char and represented in C# as 2 chars
        public string Find(string word)
        {
            var charMap = new Dictionary<string, int>();
            var charEnum = StringInfo.GetTextElementEnumerator(word);

            while (charEnum.MoveNext())
            {
                var ch = charEnum.GetTextElement();

                if (!charMap.ContainsKey(ch))
                {
                    charMap.Add(ch, 0);
                }

                charMap[ch] = charMap[ch] + 1;
            }

            foreach (var chCount in charMap)
            {
                if (chCount.Value == 1)
                {
                    return chCount.Key;
                }
            }

            return null;
        }
    }

}
