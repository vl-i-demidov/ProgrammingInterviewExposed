using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM The height of a tree (binary or not) is defined to be the maximum
     distance from the root node to any leaf node.
     Write a function to calculate the height of an arbitrary binary tree.
     */


    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool IsLeaf => Left == null && Right == null;
        public int Value { get; set; }

        public Node()
        {
        }

        public Node(int value)
        {
            Value = value;
        }
    }

    public class HeightCalculator
    {
        //O(n)
        public int CalcTreeHeightBinaryTree(Node root)
        {
            int rightDepth = root.Right != null ? CalcTreeHeightBinaryTree(root.Right) + 1 : 1;
            int leftDepth = root.Left != null ? CalcTreeHeightBinaryTree(root.Left) + 1 : 1;

            return Math.Max(rightDepth, leftDepth);
        }

    }

}
