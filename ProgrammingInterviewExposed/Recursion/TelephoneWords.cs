using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Recursion
{
    /*
      PROBLEM People in the United States sometimes give others their telephone
      number as a word representing the seven-digit number after the area code. For
      example, if my telephone number were 866-2665, I could tell people my number
      is “TOOCOOL,” instead of the hard-to-remember seven-digit number. Note that
      many other possibilities (most of which are nonsensical) can represent 866-2665.
      
          Write a function that takes a seven-digit telephone number and prints out all
      of the possible “words” or combinations of letters that can represent the given
      number. Because the 0 and 1 keys have no letters on them, you should change
      only the digits 2–9 to letters. You’ll be passed an array of seven integers, with
      each element being one digit in the number. You may assume that only valid
      phone numbers will be passed to your function. You can use the helper function
            char getCharKey( int telephoneKey, int place )
      which takes a telephone key (0–9) and a place of either 1, 2, 3 and returns the
      character corresponding to the letter in that position on the specified key. For
      example, GetCharKey(3,2) will return “E” because the telephone key 3 has the
      letters “DEF” on it and “E” is the second letter.
     */

    class TelephoneWords
    {
        private readonly int[] _digits;
        private readonly char[] _str;
        private readonly List<string> _results;

        public TelephoneWords(int[] digits)
        {
            _digits = digits;
            _str = new char[digits.Length];
            _results = new List<string>();
        }

        public List<string> Find()
        {
            _results.Clear();

            AppendDigChar(0, 1);

            return _results;
        }

        private void AppendDigChar(int digitIndex, int place)
        {
            if (digitIndex >= _digits.Length) return;

            var d = _digits[digitIndex];

            if ((d == 1 || d == 0) && place > 1) return;
            if (place > 3) return;

            var ch = GetCharKey(d, place);
            _str[digitIndex] = ch;

            if (digitIndex == _digits.Length - 1)
            {
                _results.Add(new string(_str));
            }
            else
            {
                AppendDigChar(digitIndex + 1, 1);
            }
            AppendDigChar(digitIndex, place + 1);
        }

        private char GetCharKey(int telephoneKey, int place)
        {
            Dictionary<int, char[]> map = new Dictionary<int, char[]>
            {
                {1, null },
                {2, new []{'A', 'B', 'C'} },
                {3, new []{'D', 'E', 'F'} },
                {4, new []{'G', 'H', 'I'} },
                {5, new []{'J', 'K', 'L'} },
                {6, new []{'M', 'N', 'O'} },
                {7, new []{'P', 'R', 'S'} },
                {8, new []{'T', 'U', 'V'} },
                {9, new []{'X', 'Y', 'Z'} },
                {0, null }
            };

            var chars = map[telephoneKey];
            return chars == null ? Char.Parse(telephoneKey.ToString()) : chars[place - 1];
        }
    }
}
