using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    public class ThreadPools
    {
        public void ThreadPoolDemo()
        {

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread); //False

            Employee employee = new Employee();
            employee.Name = "ABC";
            employee.CompanyName = "ABCC";

            //Thread coming from ThreadPool
            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee); //False

            var processorCount = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(processorCount*2,processorCount*2);

            int workerThreads = 0;
            int completionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);

            ThreadPool.SetMaxThreads(workerThreads*2,workerThreads*2);

            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);

        }

        private static void DisplayEmployeeInfo(object employee)
        {
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread); //True
            Employee emp = employee as Employee;
            Console.WriteLine("Person name is {0} and {1}",emp.Name,emp.CompanyName);

        }
    }

    class Employee
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
    }
}
