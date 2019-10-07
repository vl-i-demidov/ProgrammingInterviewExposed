using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewExposed.LinkedList
{
    public class ListFlatteningTests
    {
        private readonly ITestOutputHelper _output;

        public ListFlatteningTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void FlattensRight()
        {
            var n1l1 = new Node(11);
            var n2l1 = new Node(12);
            var n3l1 = new Node(13);
            var n1l2 = new Node(21);
            var n2l2 = new Node(22);
            var n1l3 = new Node(31);
            var n1l4 = new Node(41);

            n1l1.Next = n2l1;
            n2l1.Previous = n1l1;
            n2l1.Next = n3l1;
            n3l1.Previous = n2l1;

            n2l1.Child = n1l2;

            n1l2.Next = n2l2;
            n2l2.Previous = n1l2;

            n1l2.Child = n1l3;

            n1l3.Child = n1l4;

            PrintNode(n1l1);

            var fl=new ListFlattener();
            fl.FlattenList(n1l1, null);

            PrintNode(n1l1);
        }

        [Fact]
        public void Flattens2Right()
        {
            var n1l1 = new Node(11);
            var n2l1 = new Node(12);
            var n3l1 = new Node(13);
            var n1l2 = new Node(21);
            var n2l2 = new Node(22);
            var n1l3 = new Node(31);
            var n1l4 = new Node(41);

            n1l1.Next = n2l1;
            n2l1.Previous = n1l1;
            n2l1.Next = n3l1;
            n3l1.Previous = n2l1;

            n2l1.Child = n1l2;

            n1l2.Next = n2l2;
            n2l2.Previous = n1l2;

            n1l2.Child = n1l3;

            n1l3.Child = n1l4;

            PrintNode(n1l1);

            var fl = new ListFlattener();
            fl.FlattenList2(n1l1, n3l1);

            PrintNode(n1l1);
        }

        private void PrintNode(Node head)
        {
            var print = "";
            var parents = new List<Node>();

            var n = head;
            while (n != null)
            {
                if (n.Child != null)
                {
                    parents.Add(n);
                }

                print += $"{n.Value}\t";
                n = n.Next;
            }

            _output.WriteLine(print);

            foreach (var pn in parents)
            {
                _output.WriteLine($"({pn.Value}) is parent of:");
                PrintNode(pn.Child);
            }
        }

    }
}
