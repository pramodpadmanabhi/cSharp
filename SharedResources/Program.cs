using System;
using System.Threading;

namespace SharedResources
{
    //Resource Sharing 
        //Right Locking Strategy
    class Program
    {
        private static bool isCompleted;
        static readonly object lockCompleted = new object();
        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            //Worker Thread
            thread.Start();
            //Main Thread
            HelloWorld();

        }

        // Both Main and Worker thread both access same resource
        // Print the msg twice but which thread executes first not sure
        // How to solve this Problem? -- By Locking
        private static void HelloWorld()
        {
            lock (lockCompleted) // Locking , waits for thread and next thread waits the previous thread execution
            {
                if (!isCompleted)
                {
                    Console.WriteLine("Hello World should print only once");
                    isCompleted = true;
                }
            }
        }
          
    }
}
