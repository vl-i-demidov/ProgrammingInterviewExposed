using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInterviewExposed.Concurrency
{
    /*
      PROBLEM Five introspective and introverted philosophers are sitting at a circular
      table. In front of each philosopher is a plate of food. A fork lies between each
      philosopher, one by the philosopher’s left hand and one by the right hand. A philosopher
      cannot eat until he or she has forks in both hands. Forks are picked up
      one at a time. If a fork is unavailable, the philosopher simply waits for the fork
      to be freed. When a philosopher has two forks, he or she eats a few bites and
      then returns both forks to the table. If a philosopher cannot obtain both forks
      for a long time, he or she will starve. Is there an algorithm that will ensure that
      no philosophers starve?
     */



    class TheDiningPhilosophers
    {
        private readonly object[] _forks;
        private readonly Philosopher[] _philosophers;
        private readonly Action<string> _writeLine;

        public TheDiningPhilosophers(int count, Action<string> writeLine)
        {
            _forks = new object[count];
            _philosophers = new Philosopher[count];
            _writeLine = writeLine;

            for (int i = 0; i < count; i++)
            {
                _forks[i] = new object();

                int fork1 = i;
                int fork2 = (i + 1) % count;

                //deadlock solution
                //we can end up with the situation when all philosophers are holding
                //a fork in the left hand and waiting for the 2nd fork which they will never get
                //_philosophers[i] = new Philosopher(fork1, fork2, this);

                //only one philosopher takes first a fork not in their counterclockwise order
                //i.e others take #n (left) and then #n+1, but he takes #0 and then n-1
                //if we change the order in this case then all locks on forks will be acquired in order
                //and there will be no deadlock
                if (fork1 < fork2)
                {
                    _philosophers[i] = new Philosopher(i, fork1, fork2, this);
                }
                else
                {
                    _philosophers[i] = new Philosopher(i, fork2, fork1, this);
                }

                //alternative
                //in the previous solution one philosopher eat too much and the other one too less
                //because one has both forks wich are taken second by his neighbours
                //and the other one - taken first
                //we can make eating fair (almost fair for odd number of philosophers) if 
                //philosopher should pick an even numbered fork before an odd numbered fork

                //if ((i % 2) == 0)
                //{
                //    _philosophers[i] = new Philosopher(i, fork2, fork1, this);
                //}
                //else
                //{
                //    _philosophers[i] = new Philosopher(i, fork1, fork2, this);
                //}
            }

        }

        public void StartEating()
        {
            Task.Run(() =>
            {
                for (int i = 0; i < _philosophers.Length; i++)
                {
                    Task.Run(_philosophers[i].StartDinner);
                }
            });
        }

        private void Message(string msg)
        {
            _writeLine(msg);
        }

        private class Philosopher
        {
            private readonly int _id;
            private readonly int _fork1;
            private readonly int _fork2;
            private readonly TheDiningPhilosophers _dinner;

            public Philosopher(int id, int fork1, int fork2, TheDiningPhilosophers dinner)
            {
                _id = id;
                _fork1 = fork1;
                _fork2 = fork2;
                _dinner = dinner;
            }

            public void StartDinner()
            {
                while (true)
                {
                    Message($"Ready to eat with forks #{_fork1} & #{_fork2}");

                    lock (_dinner._forks[_fork1])
                    {
                        Message($"Took first fork #{_fork1}");

                        lock (_dinner._forks[_fork2])
                        {
                            Message($"Took second fork #{_fork2}. Eating...");
                            Task.Delay(200).Wait();
                        }
                    }
                }
            }

            private void Message(string msg)
            {
                _dinner.Message($"{_id}: {msg}");
            }
        }
    }
}
