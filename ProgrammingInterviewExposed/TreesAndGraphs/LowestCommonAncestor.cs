using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM Given the value of two nodes in a binary search tree, find the lowest
     (nearest) common ancestor. You may assume that both values already exist in
     the tree.
     */

    class CommonAncestorResolver
    {
        //O(log(n))
        public Node FindLowest(Node root, int valueA, int valueB)
        {
            int max = Math.Max(valueA, valueB);
            int min = Math.Min(valueA, valueB);
            var node = root;

            while (node != null)
            {
                var rootValue = node.Value;
                if (rootValue >= min && rootValue < max)
                {
                    return node;
                }

                if (min < rootValue)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }
            return null;
        }

        public Node FindLowestRecursive(Node root, int valueA, int valueB)
        {
            int max = Math.Max(valueA, valueB);
            int min = Math.Min(valueA, valueB);
            var node = root;

            GetNextLowestRecursive(ref node, min, max);
            return node;
        }

        private void GetNextLowestRecursive(ref Node root, int min, int max)
        {
            if (root.Value >= min && root.Value < max)
            {
                return;
            }

            root = min < root.Value ? root.Left : root.Right;
            GetNextLowestRecursive(ref root, min, max);
        }
    }
}
