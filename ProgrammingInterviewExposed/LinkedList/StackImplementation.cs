using System;
using System.Collections.Generic;
using System.Text;

namespace ProgrammingInterviewExposed.LinkedList
{
    class LinkedListElement<T>
    {
        public LinkedListElement(LinkedListElement<T> next, T data)
        {
            Next = next;
            Data = data;
        }

        public LinkedListElement<T> Next { get; private set; }
        public T Data { get; }

        public void SetNext(LinkedListElement<T> el)
        {
            Next = el;
        }
    }


    interface IStack<T>
    {
        void Push(T data);
        T Pop();
        T Peek();
    }

    class LinkedListStack<T> : IStack<T>
    {
        private LinkedListElement<T> _head;

        //O(1)
        public void Push(T data)
        {
            var el = new LinkedListElement<T>(null, data);

            if (_head == null)
            {
                _head = el;
            }
            else
            {
                el.SetNext(_head);
                _head.SetNext(null);
                _head = el;
            }
        }

        //O(1)
        public T Pop()
        {
            AssertStackIsNotEmpty();

            var headData = _head.Data;

            _head = _head.Next;
            return headData;
        }

        //O(1)
        public T Peek()
        {
            AssertStackIsNotEmpty();
            return _head.Data;
        }

        private void AssertStackIsNotEmpty()
        {
            if (_head == null)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }
        }
    }


    class BadLinkedListStack<T> : IStack<T>
    {
        private LinkedListElement<T> _head;

        //O(n)
        public void Push(T data)
        {
            var lle = new LinkedListElement<T>(null, data);
            if (_head == null)
            {
                _head = lle;
            }
            else
            {
                var lastEl = GetLast();
                lastEl.SetNext(lle);
            }
        }

        //O(n)
        public T Pop()
        {
            AssertStackIsNotEmpty();

            if (_head.Next == null)
            {
                var data = _head.Data;
                _head = null;
                return data;
            }

            var preLastEl = _head;
            var lastEl = _head.Next;
            while (lastEl.Next != null)
            {
                preLastEl = lastEl;
                lastEl = lastEl.Next;
            }

            preLastEl.SetNext(null);
            return lastEl.Data;
        }


        //O(n)
        public T Peek()
        {
            AssertStackIsNotEmpty();
            return GetLast().Data;
        }

        private LinkedListElement<T> GetLast()
        {
            var lastEl = _head;
            while (lastEl.Next != null)
            {
                lastEl = lastEl.Next;
            }
            return lastEl;
        }



        private void AssertStackIsNotEmpty()
        {
            if (_head == null)
            {
                throw new ArgumentOutOfRangeException("Stack is empty");
            }
        }
    }
}
