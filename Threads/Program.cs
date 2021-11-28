using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
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
