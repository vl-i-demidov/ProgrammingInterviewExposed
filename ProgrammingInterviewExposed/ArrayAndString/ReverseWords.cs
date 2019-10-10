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

        //Walking from the end of source string
        //when we find the word's end, copy word to a buffer
        public static string ReverseGeneral(string sentence)
        {
            var chars = sentence.ToCharArray();
            var buffer = new char[chars.Length];

            int bufferPos = 0;
            int tokenReadPos = chars.Length - 1;

            while (tokenReadPos >= 0)
            {
                if (chars[tokenReadPos] == ' ')
                {
                    buffer[bufferPos++] = chars[tokenReadPos--];
                }
                else
                {
                    int wordEnd = tokenReadPos;
                    while (tokenReadPos >= 0 && chars[tokenReadPos] != ' ')
                    {
                        tokenReadPos--;
                    }

                    int wordStart = tokenReadPos + 1;

                    while (wordEnd >= wordStart)
                    {
                        buffer[bufferPos] = chars[wordStart];
                        bufferPos++;
                        wordStart++;
                    }
                }
            }

            return new string(buffer);
        }


        //Reversing string in place (use same char array as source string)
        //More useful in C/C++
        public static string Reverse2(string sentence)
        {
            var chars = sentence.ToCharArray();

            //1. Reverse all letters, so that "Hello, World!" becomes "!dlroW ,olleH"
            Reverse(chars, 0, chars.Length - 1);

            //2. Reverse each word separately: "!dlroW ,olleH" -> "World! Hello,"

            int start = 0, end = 0;

            while (end <= chars.Length)
            {
                if (end == chars.Length || chars[end] == ' ')
                {
                    Reverse(chars, start, end - 1);
                    start = end + 1;
                }
                end++;
            }

            return new string(chars);
        }

        //Reversing string in place
        //almost the same as Reverse2
        public static string Reverse3(string sentence)
        {
            var chars = sentence.ToCharArray();

            //1. Reverse all letters, so that "Hello, World!" becomes "!dlroW ,olleH"
            Reverse(chars, 0, chars.Length - 1);

            //2. Reverse each word separately: "!dlroW ,olleH" -> "World! Hello,"

            int end = 0;

            while (end < chars.Length)
            {
                if (chars[end] != ' ')
                {
                    var start = end;

                    while (end < chars.Length && chars[end] != ' ')
                    {
                        end++;
                    }

                    end--;

                    Reverse(chars, start, end);
                }

                end++;
            }

            return new string(chars);
        }

        private static void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                var temp = str[start];
                str[start] = str[end];
                str[end] = temp;

                start++;
                end--;
            }
        }
    }




}

