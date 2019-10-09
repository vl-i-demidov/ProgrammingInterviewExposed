﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.ArrayAndString
{
    public class FirstNonrepeatedCharacterTests
    {
        [Fact]
        public void FindNonrepeatedCharacterRightNaive()
        {
            var program = new FirstNonrepeatedCharacter();
            Assert.Equal('o', program.FindNaive("total"));
            Assert.Equal('r', program.FindNaive("teeter"));
        }

    }
}
