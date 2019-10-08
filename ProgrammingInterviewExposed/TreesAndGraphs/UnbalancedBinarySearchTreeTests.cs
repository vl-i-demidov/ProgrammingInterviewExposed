using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    public class UnbalancedBinarySearchTreeTests
    {
        [Fact]
        public void BalancesRight()
        {
            var root = new Node(6)
            {
                Left = new Node(4)
                {
                    Left = new Node(2)
                    {
                        Left = new Node(1),
                        Right = new Node(3)
                    },
                    Right = new Node(5)
                },
                Right = new Node(7)
            };

            TreeBalancer balancer = new TreeBalancer();
            var balancedRoot = balancer.BalanceTree(root);

            AssertIsBinarySearchTree(balancedRoot);
        }

        [Fact]
        public void BalancesRightWithRotate()
        {
            var root = new Node(6)
            {
                Left = new Node(4)
                {
                    Left = new Node(2)
                    {
                        Left = new Node(1),
                        Right = new Node(3)
                    },
                    Right = new Node(5)
                },
                Right = new Node(7)
            };

            TreeBalancer balancer = new TreeBalancer();
            var balancedRoot = balancer.BalanceTreeRotate(root);

            AssertIsBinarySearchTree(balancedRoot);
        }

        private void AssertIsBinarySearchTree(Node root)
        {
            if (root.Left != null)
            {
                Assert.True(root.Value >= root.Left.Value);
                AssertIsBinarySearchTree(root.Left);
            }

            if (root.Right != null)
            {
                Assert.True(root.Value < root.Right.Value);
                AssertIsBinarySearchTree(root.Right);
            }
        }

    }
}
