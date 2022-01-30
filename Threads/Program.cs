using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkernMainThread();

            //ThreadPools threadPools = new ThreadPools();
            //threadPools.ThreadPoolDemo();

            //ThreadsJoin threadsJoin = new ThreadsJoin();
            //threadsJoin.ThreadJoin();


            Acccount account = new Acccount(20000);
            Task task1 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task task2 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task task3 = Task.Factory.StartNew(() => account.WithdrawRandomly());
            Task.WaitAll(task1,task2,task3);

            Console.WriteLine("All tasks complete");

            Console.ReadKey();
        }

       
        private static void WorkernMainThread()
        {
            Thread thread = new Thread(WriteUsingNewThread);
            thread.Name = "Pramod Worker";
            //Worker Thread
            thread.Start();
            //Main Thread
            Thread.CurrentThread.Name = "Pramod Main";
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A" + i + " ");

            }
        }
        private static void WriteUsingNewThread(object obj)
        {
            for (int i= 0; i < 1000; i++)
            {
                Console.Write("Z" + i + " ");

            }
        }

        
    }
}
