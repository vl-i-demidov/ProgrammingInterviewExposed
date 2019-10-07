using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    /*
     PROBLEM Unflatten the list created by the previous problem and restore the
     data structure to its original condition.
     */

    public class ListUnflattener
    {
        //restoring initial state from flattened listed
        //as implemented in ListFlattener.FlattenList is impossible


        public void UnflattenList(Node head)
        {
            var n = head;
            while (n != null)
            {
                if (n.Child != null)
                {
                    //terminate the list before the child
                    n.Child.Previous.Next = null;
                    n.Child.Previous = null;
                    UnflattenList(n.Child);
                }

                n = n.Next;
            }
        }


        public Node FlattenList(Node head, Node tail)
        {
            var n = head;
            while (n != null)
            {
                if (n.Child != null)
                {
                    Append(n.Child, ref tail);
                }
                n = n.Next;
            }
            return head;
        }

        private void Append(Node child, ref Node tail)
        {
            Node curNode;
            tail.Next = child;
            child.Previous = tail;

            for (curNode = child; curNode.Next != null; curNode = curNode.Next)
            {
            }

            tail = curNode;
        }
    }
}
