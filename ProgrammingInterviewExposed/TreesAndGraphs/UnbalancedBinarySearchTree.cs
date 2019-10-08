using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM Given an unbalanced binary search tree with more nodes in the left
     subtree than the right, reorganize the tree to improve its balance while maintaining
     the properties of a binary search tree
     */

    class TreeBalancer
    {
        //O(n) runtime, O(n) space
        public Node BalanceTree(Node root)
        {
            var nodes = new List<Node>();
            TraverseOrder(root, n => nodes.Add(n));
            var nodeArray = nodes.ToArray();

            return BalanceTreeArray(nodeArray, 0, nodeArray.Length - 1);
        }

        //O(1) runtime, O(1) space
        public Node BalanceTreeRotate(Node root)
        {
           return RotateRight(root);
        }

        //tree rotation algorithm
        //take a root, make it's left child a new root, make left child's right leaf left leaf of old root
        private Node RotateRight(Node oldRoot)
        {
            var newRoot = oldRoot.Left;
            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;

            return newRoot;
        }


        private void TraverseOrder(Node root, Action<Node> action)
        {
            if (root.Left != null)
            {
                action(root.Left);
            }

            action(root);

            if (root.Right != null)
            {
                action(root.Right);
            }
        }

        private Node BalanceTreeArray(Node[] array, int startIndex, int endIndex)
        {
            //binary search tree

            int middleIndex = (int)Math.Ceiling((endIndex + startIndex) / 2.0);

            var node = array[middleIndex];
            node.Left = null;
            node.Right = null;

            if (startIndex == endIndex)
            {
                return node;
            }

            node.Left = BalanceTreeArray(array, startIndex, middleIndex - 1);

            if (endIndex > middleIndex)
            {
                node.Right = BalanceTreeArray(array, middleIndex + 1, endIndex);
            }

            return node;
        }
    }
}
