using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.TreesAndGraphs
{
    /*
     PROBLEM Perform a preorder traversal of a binary search tree, printing the
     value of each node, but this time you may not use recursion.
     */


    class NoRecursionPreorderNodePrinter
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
            var node = root;
            Stack<Node> toProcess = new Stack<Node>();

            while (true)
            {
                action(node);
                if (node.Left != null)
                {
                    if (node.Right != null)
                    {
                        toProcess.Push(node.Right);
                    }
                    node = node.Left;
                }
                else if (node.Right != null)
                {
                    node = node.Right;
                }
                else if (toProcess.Count > 0)
                {
                    node = toProcess.Pop();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
