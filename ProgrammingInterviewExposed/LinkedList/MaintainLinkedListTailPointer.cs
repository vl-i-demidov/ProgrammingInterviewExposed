using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    /*
    PROBLEM head and tail are global pointers to the first and last element, respectively,
    of a singly linked list of integers. Implement C functions for the following
    prototypes:
    bool delete( Element *elem );
    bool insertAfter( Element *elem, int data );
    The argument to delete is the element to be deleted. The two arguments to
    insertAfter give the element after which the new element is to be inserted and
    the data for the new element. It should be possible to insert at the beginning of the
    list by calling insertAfter with NULL as the element argument. These functions
    should return a boolean indicating success.
    Your functions must keep the head and tail pointers current.
     */

    interface IDeleteInsertAfterLinkedList<T>
    {
        LinkedListElement<T> Add(T data);
        bool Delete(LinkedListElement<T> el);
        bool InsertAfter(LinkedListElement<T> el, T data);
    }

    class DeleteInsertAfterLinkedList<T> : IDeleteInsertAfterLinkedList<T>
    {
        private LinkedListElement<T> _head;
        private LinkedListElement<T> _tail;

        public LinkedListElement<T> Head => _head;
        public LinkedListElement<T> Tail => _tail;

        public LinkedListElement<T> Add(T data)
        {
            var el = new LinkedListElement<T>(data);
            if (_head == null)
            {
                _head = el;
                _tail = el;
            }
            else
            {
                _tail.SetNext(el);
                _tail = el;
            }
            return el;
        }

        public bool Delete(LinkedListElement<T> el)
        {
            var prev = (LinkedListElement<T>)null;
            var cur = _head;

            while (cur != el && cur != null)
            {
                prev = cur;
                cur = cur.Next;
            }

            if (cur == null)
            {
                return false;
            }

            //if removing head
            if (prev == null)
            {
                _head = cur.Next;
            }

            //if removing tail
            if (cur.Next == null)
            {
                _tail = prev ?? _head;
            }

            if (prev != null)
            {
                prev.SetNext(cur.Next);
            }

            return true;
        }

        public bool InsertAfter(LinkedListElement<T> el, T data)
        {
            var newEl = new LinkedListElement<T>(data);

            //insert before head
            if (el == null)
            {
                //if 0 elements in list
                if (_head == null)
                {
                    _head = newEl;
                    _tail = newEl;
                    return true;
                }

                var oldHead = _head;

                newEl.SetNext(oldHead);

                //only 1 element in list
                if (oldHead.Next == null)
                {
                    _tail = _head;
                }
                _head = newEl;
                return true;
            }

            var cur = _head;

            while (cur != el && cur != null)
            {
                cur = cur.Next;
            }

            //couldn't find
            if (cur == null)
            {
                return false;
            }

            var next = cur.Next;

            cur.SetNext(newEl);

            if (next == null)
            {
                _tail = newEl;
            }

            newEl.SetNext(next);
            return true;
        }
    }
}
