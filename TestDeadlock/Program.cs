using System;
using System.Threading;

namespace TestDeadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                var worker = new Worker();

                //var thread1 = new Thread(worker.Start);
                //var thread2 = new Thread(worker.Work);

                //thread1.Start();
                //thread2.Start();

                ThreadPool.QueueUserWorkItem((x) => worker.Start());
                ThreadPool.QueueUserWorkItem((x) => worker.Work());

                Console.WriteLine("Press any key to exit");
                Console.WriteLine();

            }
        }
    }

    public class Worker
    {
        private static object A = new object();
        private static object B = new object();

        public void Start()
        {
            lock (A)
            {
                var processorId = Thread.GetCurrentProcessorId();
                var name = Thread.CurrentThread.Name;
                var threadId = Thread.CurrentThread.Priority;
                var priority = Thread.CurrentThread.ManagedThreadId;
                var threadState = Thread.CurrentThread.ThreadState;
                var isThreadPoolThread = Thread.CurrentThread.IsBackground;

                lock (B)
                {
                    Console.WriteLine("processorId: " + processorId);
                    Console.WriteLine("processorId: " + name);
                    Console.WriteLine("processorId: " + threadId);
                    Console.WriteLine("processorId: " + priority);
                    Console.WriteLine("processorId: " + threadState);
                    Console.WriteLine("processorId: " + isThreadPoolThread);

                }
            }
        }

        public void Work()
        {
            lock (B)
            {
                var processorId = Thread.GetCurrentProcessorId();
                var name = Thread.CurrentThread.Name;
                var threadId = Thread.CurrentThread.Priority;
                var priority = Thread.CurrentThread.ManagedThreadId;
                var threadState = Thread.CurrentThread.ThreadState;
                var isThreadPoolThread = Thread.CurrentThread.IsBackground;

                lock (A)
                {
                    Console.WriteLine("processorId: " + processorId);
                    Console.WriteLine("processorId: " + name);
                    Console.WriteLine("processorId: " + threadId);
                    Console.WriteLine("processorId: " + priority);
                    Console.WriteLine("processorId: " + threadState);
                    Console.WriteLine("processorId: " + isThreadPoolThread);

                }
            }
        }
    }
}
