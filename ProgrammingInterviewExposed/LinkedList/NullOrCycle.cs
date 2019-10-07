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

        //Floyd’s Cycle detection algorithm
        public bool IsCyclicListFloyd<T>(LinkedListElement<T> head)
        {
            /*
             Start slow pointer at the head of the list
            Start fast pointer at second node
            Loop infinitely
                If the fast pointer reaches a null pointer
                    Return that the list is null terminated
                If the fast pointer moves onto or over the slow pointer
                    Return that there is a cycle
                Advance the slow pointer one node
                Advance the fast pointer two nodes
             */


            var slow = head;
            var fast = head.Next;

            while (true)
            {
                if (fast == null || fast.Next == null)
                {
                    return false;
                }

                if (fast == slow || fast.Next == slow)
                {
                    return true;
                }

                slow = slow.Next;
                fast = fast.Next.Next;
            }
        }
    }

}
