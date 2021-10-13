using System;
using System.Collections.Generic;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            ThreadPool.QueueUserWorkItem((x) => worker.Start());
            ThreadPool.QueueUserWorkItem((x) => worker.Start());


            worker.ThreadMutex();

            worker.AddNumber();

            worker.Start();
            worker.Start();
            worker.Start();

        }
    } 


    public class Worker
    {
        private List<int> _numbers = new List<int>();
        private int _counter = 0;
        private Random _random = new Random();

        private object locker = new object();

        //private Mutex _mutex = new Mutex();

        private static Mutex _mutex = new Mutex(false, "Mutex");



        public void Start()
        {
            while (true)
            {
                var guid = Guid.NewGuid();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine(guid);

                Thread.SpinWait(100_000);

                Thread.Sleep(100);

                _counter++;
            }


        }


        public void AddNumber()
        {
            lock (locker)
            {
                _numbers.Add(_random.Next());
                _counter++;

            }
        }

        public void ThreadMutex()
        {
            _mutex.WaitOne();

            for (int i = 0; i < 10; i++)
            {
                _counter++;
                Console.WriteLine(_counter);

                Thread.Sleep(300);
            }

            _mutex.ReleaseMutex();
        }
    }
}
