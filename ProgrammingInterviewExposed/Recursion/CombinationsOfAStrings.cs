using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.Recursion
{
    /*
      PROBLEM Implement a function that prints all possible combinations of the
      characters in a string. These combinations range in length from one to the length
      of the string. Two combinations that differ only in ordering of their characters
      are the same combination. In other words, “12” and “31” are different combinations
      from the input string “123”, but “21” is the same as “12”.
     */

    class CombinationsOfAStrings
    {
        private readonly string _input;

        private readonly List<string> _results;

        public CombinationsOfAStrings(string input)
        {
            _input = input;
            _results = new List<string>();
        }

        public List<string> Combine()
        {
            _results.Clear();
            Combine(0, "");

            return _results;
        }

        private void Combine(int start, string prefix)
        {
            for (int i = start; i < _input.Length; i++)
            {
                var res = prefix + _input[i];
                _results.Add(res);

                Combine(i + 1, res);
            }
        }

    }

    //(book implementation)
    //almost similar with 1st one
    //instead of using prefix in Combine(), we use StringBuilder 
    //and synchronize it's length on exit of recursive call
    class CombinationsOfAStrings2
    {
        private readonly string _input;
        private readonly StringBuilder _output;

        private readonly List<string> _results;

        public CombinationsOfAStrings2(string input)
        {
            _input = input;
            _results = new List<string>();
            _output = new StringBuilder();
        }

        public List<string> Combine()
        {
            _results.Clear();
            _output.Clear();

            Combine(0);

            return _results;
        }

        private void Combine(int start)
        {
            for (int i = start; i < _input.Length; i++)
            {
                //append char
                _output.Append(_input[i]);
                
                _results.Add(_output.ToString());

                Combine(i + 1);

                //remove char (synchronize length)
                _output.Length -= 1;
            }
        }

    }
}
