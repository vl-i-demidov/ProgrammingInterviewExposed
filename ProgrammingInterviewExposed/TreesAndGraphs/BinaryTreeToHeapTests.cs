using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class BinaryTreeToHeapTests
    {
        private readonly ITestOutputHelper _output;

        public BinaryTreeToHeapTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CreatesMaxHeapRight()
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

            BinaryTreeHeap h = new BinaryTreeHeap();
            var tree = h.Create(root);


            //check if every parent is larger than its child
            AssertChildrenSmaller(tree);
        }

        [Fact]
        public void CreatesMaxHeapRight2()
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

            BinaryTreeHeap h = new BinaryTreeHeap();
            var tree = h.Create2(root);


            //check if every parent is larger than its child
            AssertChildrenSmaller(tree);
        }

        private void AssertChildrenSmaller(Node root)
        {
            if (root == null)
            {
                return;
            }

            if (root.Left != null)
            {
                Assert.True(root.Value >= root.Left.Value);
                AssertChildrenSmaller(root.Left);
            }

            if (root.Right != null)
            {
                Assert.True(root.Value >= root.Right.Value);
                AssertChildrenSmaller(root.Right);
            }
        }


    }
}
