using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM You are given a set of integers in an unordered binary tree. Use an
     array sorting routine to transform the tree into a heap that uses a balanced binary
     tree as its underlying data structure.
     */

    class HNode : Node
    {
        public Node Parent { get; set; }

        public HNode(int value, Node parent) : base(value)
        {
            Parent = parent;
        }
    }

    class BinaryTreeHeap
    {
        private HNode _tree;

        public Node Create(Node root)
        {
            //1.Create an array from unordered binary tree
            //2.Sort the array
            //3.Use the array to create balanced binary tree
            //4.Implement heap interface that uses balanced binary tree as underlying data structure

            //1.
            var array = ArrayFromTree(root);
            //2.
            Array.Sort(array);
            //3.
            _tree = BalancedMaxBinaryTreeFromArray(array, 0, array.Length - 1, null);

            return _tree;
        }


        private HNode BalancedMaxBinaryTreeFromArray(int[] array, int startIndex, int endIndex, HNode parent)
        {
            //binary tree, max-heap

            var node = new HNode(array[endIndex], parent);

            if (startIndex == endIndex)
            {
                return node;
            }

            int middleIndex = (int)Math.Ceiling((endIndex - 1 + startIndex) / 2.0);

            node.Left = BalancedMaxBinaryTreeFromArray(array, startIndex, middleIndex, node);

            if (endIndex - 1 >= middleIndex + 1)
            {
                node.Right = BalancedMaxBinaryTreeFromArray(array, middleIndex + 1, endIndex - 1, node);
            }

            return node;
        }

        private Node BalancedBinaryTreeFromArray(int[] array, int startIndex, int endIndex)
        {
            //binary search tree

            int middleIndex = (int)Math.Ceiling((endIndex + startIndex) / 2.0);

            var node = new Node(array[middleIndex]);

            if (startIndex == endIndex)
            {
                return node;
            }

            node.Left = BalancedBinaryTreeFromArray(array, startIndex, middleIndex - 1);

            if (endIndex > middleIndex)
            {
                node.Right = BalancedBinaryTreeFromArray(array, middleIndex + 1, endIndex);
            }

            return node;
        }

        private int[] ArrayFromTree(Node root)
        {
            var list = new List<int>();
            TraverseTree(root, n => list.Add(n.Value));
            return list.ToArray();
        }

        private void TraverseTree(Node root, Action<Node> action)
        {
            if (root == null)
            {
                return;
            }
            action(root);
            action(root.Left);
            action(root.Right);
        }

    }

}
