using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class ThreadsJoin
    {
       public void ThreadJoin()
        {
            Thread thread = new Thread(PrintHelloWorld);
            thread.Start();
            thread.IsBackground = true; //Makes the thread background which is destroyed after main thread is killed
            thread.Join();  //Waits for all the thread to complete
            Console.WriteLine("Hello World Printed");

        }
        private static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World");
            Thread.Sleep(5000); //Sleeps or Blocks the thread for 5 seconds
        }
    }
}