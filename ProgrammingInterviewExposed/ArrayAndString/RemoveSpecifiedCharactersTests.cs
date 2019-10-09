using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class RemoveSpecifiedCharactersTests
    {
        [Fact]
        public void RemovesSpecifiedCharactersRight()
        {
            var str = "Battle of the Vowels: Hawaii vs. Grozny";
            var remove = "aeiou";

            Assert.Equal("Bttl f th Vwls: Hw vs. Grzny", RemoveSpecifiedCharacters.RemoveChars(str, remove));
        }
    }
}
