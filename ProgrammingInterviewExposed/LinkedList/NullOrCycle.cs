using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    /*
     PROBLEM You are given a linked list with at least one node that is either null terminated (acyclic).
     Write a function that takes a pointer to the head of a list and determines whether
     the list is cyclic or acyclic. Your function should return false if the list is acyclic
     and true if it is cyclic. You may not modify the list in any way.
     */

    public class NullOrCycleResolver
    {
        //O(n^2)
        public bool IsCyclicList<T>(LinkedListElement<T> head)
        {
            if (head.Next == head)
            {
                return true;
            }

            var n = head;
            while (n.Next != null)
            {
                var checkNode = head;
                while (checkNode != n)
                {
                    if (n.Next == checkNode)
                    {
                        return true;
                    }
                    checkNode = checkNode.Next;
                }
                n = n.Next;
            }

            return false;
        }
    }

}
