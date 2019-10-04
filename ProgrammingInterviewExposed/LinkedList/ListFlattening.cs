using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    class ListFlattening
    {
        /*
        PROBLEM Start with a standard doubly linked list. Now imagine that in addition
        to the next and previous pointers, each element has a child pointer, which
        may or may not point to a separate doubly linked list. These child lists may have
        one or more children of their own, and so on, to produce a multilevel data structure

        Flatten the list so that all the nodes appear in a single-level, doubly linked list. You
        are given the head and tail of the first level of the list. Each node is a C struct
        with the following definition:

        typedef struct Node {
            struct Node *next;
            struct Node *prev;
            struct Node *child;
            int value;
        } Node;
         */

    }


    class Node
    {
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node Child { get; set; }
        public int Value { get; set; }
    }


    class ListFlattener
    {
        public Node FlattenList(Node head, Node tail)
        {
            return null;
        }

        private Node MergeChildrenInto(Node parent)
        {
            var child = parent.Child;

            //merge grandchildren into child if they exist
            var grandChildParent = GetNextSameLevelNodeWithChild(child);
            if (grandChildParent != null)
            {
                MergeChildrenInto(grandChildParent);
            }

            //assume child has no other children
            var childHead = parent.Child;
            var childTail = GetLevelTail(childHead);
            var parentNext = parent.Next;

            parent.Child = null;
            parent.Next = childHead;
            childTail.Next = parentNext;

            return parent;
        }

        private Node GetNextSameLevelNodeWithChild(Node n)
        {
            var el = n;

            while (el != null)
            {
                if (el.Child != null)
                {
                    return el;
                }

                el = el.Next;
            }
            return null;
        }

        private Node GetLevelTail(Node head)
        {
            var n = head;
            while (n.Next != null)
            {
                n = n.Next;
            }
            return n;
        }

    }
}
