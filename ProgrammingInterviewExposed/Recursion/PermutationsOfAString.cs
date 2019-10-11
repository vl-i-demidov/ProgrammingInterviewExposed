using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Recursion
{
    /*
      PROBLEM Implement a routine that prints all possible orderings of the characters
      in a string. In other words, print all permutations that use all the characters
      from the original string. For example, given the string “hat”, your function
      should print the strings “tha”, “aht”, “tah”, “ath”, “hta”, and “hat”. Treat each
      character in the input string as a distinct character, even if it is repeated. Given
      the string “aaa”, your routine should print “aaa” six times. You may print the
      permutations in any order you choose.
    */

    class PermutationsOfAString
    {
        private bool[] _used;
        private char[] _inputWord;

        private List<string> _out;
        private StringBuilder _outWord;


        public PermutationsOfAString(string str)
        {
            _inputWord = str.ToCharArray();
            _out = new List<string>();
            _outWord = new StringBuilder();
        }

        public List<string> GetPermutations()
        {
            _used = new bool[_inputWord.Length];
            _out.Clear();
            _outWord.Clear();

            Permute();

            return _out;
        }

        private void Permute()
        {
            if (_outWord.Length == _inputWord.Length)
            {
                _out.Add(_outWord.ToString());
                return;
            }

            for (int ind = 0; ind < _inputWord.Length; ind++)
            {
                var ch = _inputWord[ind];
                if (_used[ind]) continue;

                _outWord.Append(_inputWord[ind]);
                _used[ind] = true;

                Permute();

                _used[ind] = false;

                _outWord.Length = _outWord.Length - 1;
            }
        }
    }
}
