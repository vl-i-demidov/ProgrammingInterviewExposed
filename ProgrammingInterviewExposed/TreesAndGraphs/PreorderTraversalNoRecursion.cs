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

        public string PrintStack(Node root)
        {
            var sb = new StringBuilder();
            Action<Node> printVals = n => sb.Append($"{n.Value} ");

            TraverseStack(root, printVals);

            return sb.ToString();
        }

        //O(n)
        private void Traverse(Node root, Action<Node> action)
        {
            var node = root;
            var toProcess = new Stack<Node>();

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

        //O(n)
        private void TraverseStack(Node root, Action<Node> action)
        {
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                //recursion imitation

                //1. call action
                action(node);

                //2. save state in stack
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                //3. save state to stack
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }
    }
}
