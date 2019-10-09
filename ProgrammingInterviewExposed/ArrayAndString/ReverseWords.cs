using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingInterviewExposed.ArrayAndString
{

    /*
     PROBLEM Write a function that reverses the order of the words in a string. For
     example, your function should transform the string "Do or do not, there is no
     try." to "try. no is there not, do or Do". Assume that all words are space delimited
     and treat punctuation the same as letters.
     */

    class ReverseWords
    {
        //runtime O(n)
        //space O(2n), worst O(3n)
        public static string Reverse(string sentence)
        {
            var reverse = new StringBuilder(sentence.Length);
            var word = new Stack<char>();
            for (int i = sentence.Length - 1; i >= -1; i--)
            {
                var ch = i >= 0 ? sentence[i] : Char.MinValue;

                bool wordEnd = i == -1 || Char.IsWhiteSpace(ch);

                if (wordEnd)
                {
                    while (word.Count > 0)
                    {
                        reverse.Append(word.Pop());
                    }

                    if (i != -1)
                    {
                        reverse.Append(' ');
                    }
                }
                else
                {
                    word.Push(ch);
                }
            }

            return reverse.ToString();
        }
    }

}

