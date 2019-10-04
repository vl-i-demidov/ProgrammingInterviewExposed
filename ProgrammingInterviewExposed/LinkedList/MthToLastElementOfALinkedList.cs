using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    /*
    PROBLEM Given a singly linked list, devise a time- and space-efficient algorithm
    to find the mth-to-last element of the list. Implement your algorithm, taking care
    to handle relevant error conditions. Define mth to last such that when m = 0 the
    last element of the list is returned.
     */


    public interface IMthToLastLinkedList<T>
    {
        LinkedListElement<T> Add(T data);
        LinkedListElement<T> FindMthToLast(int m);
    }

    public class MthToLastLinkedListNoCounterEfficient<T> : IMthToLastLinkedList<T>
    {
        private LinkedListElement<T> _tail;
        private LinkedListElement<T> _head;

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

        public LinkedListElement<T> FindMthToLast(int m)
        {
            if (_head == null)
            {
                return null;
            }
            int index = 0;

            var startEl = _head;
            while (index < m)
            {
                startEl = startEl.Next;
                if (startEl == null)
                {
                    return null;
                }

                index++;
            }

            var mthPrevElement = _head;

            var curEl = startEl;
            while (curEl.Next != null)
            {
                curEl = curEl.Next;
                mthPrevElement = mthPrevElement.Next;
            }

            return mthPrevElement;
        }
    }

    public class MthToLastLinkedListNoCounter<T> : IMthToLastLinkedList<T>
    {
        private LinkedListElement<T> _tail;
        private LinkedListElement<T> _head;

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

        public LinkedListElement<T> FindMthToLast(int m)
        {
            var el = _head;
            int count = 1;
            while (el.Next != null)
            {
                el = el.Next;
                count++;
            }

            int index = count - m - 1;
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            el = _head;
            int curIndex = 0;
            while (curIndex != index)
            {
                el = el.Next;
                curIndex++;
            }

            return el;
        }
    }

    public class MthToLastLinkedListSpaceEfficient<T> : IMthToLastLinkedList<T>
    {
        private LinkedListElement<T> _tail;
        private LinkedListElement<T> _head;
        private int _count = 0;

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
            _count++;

            return el;
        }

        public LinkedListElement<T> FindMthToLast(int m)
        {
            int index = _count - m - 1;
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var el = _head;
            int curIndex = 0;
            while (curIndex != index)
            {
                el = el.Next;
                curIndex++;
            }

            return el;
        }
    }

    public class MthToLastLinkedListTimeEfficient<T> : IMthToLastLinkedList<T>
    {
        private LinkedListElement<T> _tail;
        private LinkedListElement<T> _head;
        private List<LinkedListElement<T>> _array = new List<LinkedListElement<T>>();

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
            _array.Add(el);

            return el;
        }

        public LinkedListElement<T> FindMthToLast(int m)
        {
            int index = _array.Count - m - 1;
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _array[index];
        }
    }
}
