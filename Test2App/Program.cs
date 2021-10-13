using System;
using System.Threading;

namespace Test2App
{
    class Program
    {
        private static Mutex _mutex = new Mutex(false, "Mutex");

        static void Main(string[] args)
        {
            

            Console.WriteLine("Hello World!");

            ThreadPool.QueueUserWorkItem((x)=>DoAction());
        }

        private static void DoAction()
        {
            _mutex.WaitOne();


            Console.WriteLine("Test");

            _mutex.ReleaseMutex();


        }
    }
}
