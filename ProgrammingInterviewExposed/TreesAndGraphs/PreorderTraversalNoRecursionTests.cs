using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class PreorderTraversalNoRecursionTests
    {
        private readonly ITestOutputHelper _output;

        public PreorderTraversalNoRecursionTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ValuesArePrintedRight()
        {
            var root = new Node(100)
            {
                Left = new Node(50)
                {
                    Left = new Node(25),
                    Right = new Node(75),
                },
                Right = new Node(150)
                {
                    Left = new Node(125)
                    {
                        Left = new Node(110)
                    },
                    Right = new Node(175),
                },
            };

            var printer = new NoRecursionPreorderNodePrinter();
            _output.WriteLine(printer.Print(root));
        }

        [Fact]
        public void ValuesArePrintedRightStack()
        {
            var root = new Node(100)
            {
                Left = new Node(50)
                {
                    Left = new Node(25),
                    Right = new Node(75),
                },
                Right = new Node(150)
                {
                    Left = new Node(125)
                    {
                        Left = new Node(110)
                    },
                    Right = new Node(175),
                },
            };

            var printer = new NoRecursionPreorderNodePrinter();
            _output.WriteLine(printer.PrintStack(root));
        }
    }
}
