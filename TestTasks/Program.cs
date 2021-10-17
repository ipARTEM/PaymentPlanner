using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestTasks
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                var task = new Task(DoAction);

                var cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.CancelAfter(new TimeSpan(0, 0, 5));

                var task1 = new Task(() => {
                    Console.WriteLine($"Message from task 1. ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                });

                task.Start();
                task1.Start();

                var task4 =Task.Run(()=>
                Console.WriteLine($"Message from task 4. ThreadId: {Thread.CurrentThread.ManagedThreadId}"
                ));

                var task5 = Task.Run(() =>
                {
                    Task.Delay(60_000);
                    Console.WriteLine($"Message from task 5. ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                    
                
                }, cancellationTokenSource.Token);

                var task6= DoActionAsync(cancellationTokenSource.Token);



                Console.WriteLine();
                Console.ReadKey();
            }

        }

        private static  void DoAction()
        {
            Console.WriteLine($"Message from task. ThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }

        private static Task<int> DoActionAsync(CancellationToken token)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"Message from task. ThreadId DoActionAsync: {Thread.CurrentThread.ManagedThreadId}" +
                    $"ThreadId:{Thread.CurrentThread.ManagedThreadId}" +
                    $"TaskId:{Task.CompletedTask}");
                for (int i = 0; i < 100_000; i++)
                {
                    Thread.Sleep(1_000);
                    if (token.IsCancellationRequested)
                    {
                        return 100;

                    }
                }
                return 88;
             
            });
        }
    }
}
