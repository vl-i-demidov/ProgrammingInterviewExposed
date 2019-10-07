using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM Informally, a preorder traversal involves walking around the tree in
     a counter-clockwise manner starting at the root, sticking close to the edges, and
     printing out the nodes as you encounter them. Perform a preorder traversal
     of a binary search tree, printing the value of each node.
     */

    class PreorderNodePrinter
    {
        public string Print(Node root)
        {
            var sb = new StringBuilder();
            Action<Node> printVals = n => sb.Append($"{n.Value} ");
            Traverse(root, printVals);

            return sb.ToString();
        }

        private void Traverse(Node root, Action<Node> action)
        {
            if (root == null)
            {
                return;
            }
            action(root);
            Traverse(root.Left, action);
            Traverse(root.Right, action);
        }
    }
}
