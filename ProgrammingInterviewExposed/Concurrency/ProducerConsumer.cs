using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingInterviewExposed.Concurrency
{
    /*
      PROBLEM Write a producer thread and a consumer thread that share a fixedsize
      buffer and an index to access the buffer. The producer should place numbers
      into the buffer, and the consumer should remove the numbers. The order in
      which the numbers are added or removed is not important.
     */


    class NumBuffer
    {
        private int _index = -1;
        private readonly int[] _buffer;
        private readonly object _lock = new object();

        public NumBuffer(int size)
        {
            _buffer = new int[size];
        }

        public void AddNum(int n)
        {
            try
            {
                Monitor.Enter(_lock);

                while (_index >= _buffer.Length - 1)
                {
                    Monitor.Wait(_lock);
                }

                _index++;
                _buffer[_index] = n;

                Monitor.PulseAll(_lock);
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }

        public int Remove()
        {
            try
            {
                Monitor.Enter(_lock);

                while (_index < 0)
                {
                    Monitor.Wait(_lock);
                }

                int n = _buffer[_index];
                _index--;

                Monitor.PulseAll(_lock);

                return n;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }

    }

    class ProducerConsumer
    {
        private readonly NumBuffer _buffer;
        private readonly int _numCount;

        public ConcurrentBag<int> Consumed { get; private set; }

        public ProducerConsumer(int size, int numCount)
        {
            _buffer = new NumBuffer(size);
            _numCount = numCount;

            Consumed = new ConcurrentBag<int>();
        }


        public Task StartProduce()
        {            
           return Task.Run(()=> {
                for (int i = 0; i < _numCount; i++)
                {
                    _buffer.AddNum(i);
                }
            });
        }

        public void StartConsume()
        {
            Task.Run(()=> {

                while (true)
                {
                    int n=_buffer.Remove();
                    Consumed.Add(n);
                }

            });
        }

    }
}
