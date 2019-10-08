using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class LowestCommonAncestorTests
    {
        private readonly ITestOutputHelper _output;

        public LowestCommonAncestorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void LowestCommonAncestorFoundRight()
        {
            var root = new Node(20)
            {
                Left = new Node(8)
                {
                    Left = new Node(4),
                    Right = new Node(12)
                    {
                        Left = new Node(10),
                        Right = new Node(14)
                    }
                },
                Right = new Node(22)
            };

            var resolver = new CommonAncestorResolver();
            var ancestor = resolver.FindLowest(root, 4, 14);
            Assert.NotNull(ancestor);
            Assert.Equal(8, ancestor.Value);
        }

        [Fact]
        public void LowestCommonAncestorFoundRightRecursive()
        {
            var root = new Node(20)
            {
                Left = new Node(8)
                {
                    Left = new Node(4),
                    Right = new Node(12)
                    {
                        Left = new Node(10),
                        Right = new Node(14)
                    }
                },
                Right = new Node(22)
            };

            var resolver = new CommonAncestorResolver();
            var ancestor = resolver.FindLowestRecursive(root, 4, 14);
            Assert.NotNull(ancestor);
            Assert.Equal(8, ancestor.Value);
        }
    }
}
