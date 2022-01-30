using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //    long totalSize = 0;



            //    if (args.Length==0)
            //    {
            //        Console.WriteLine("There are no Command line arguments");
            //        return;
            //    }
            //    if (!Directory.Exists(args[0]))
            //    {
            //        Console.WriteLine("The directory does not exist");
            //        return;
            //    }

            //    String[] files = Directory.GetFiles(args[0]);
            //    Parallel.For(0, files.Length,
            //        index =>
            //        {
            //            FileInfo fi = new FileInfo(files[index]);
            //            long size = fi.Length;
            //            Interlocked.Add(ref totalSize, size);
            //        });

            //    Console.WriteLine("Directory '{0}' : ",args[0]);
            //    Console.WriteLine("{0:N0} files, {1:N0} bytes",files.Length,totalSize);

            //    Console.ReadKey();



            //--------------------------------------------
            //var limit = 2_000_000;
            //var numbers = Enumerable.Range(0, limit).ToList();

            //var watch = Stopwatch.StartNew();
            //var primeNumbersFromForeach = GetPrimeList(numbers);
            //watch.Stop();

            //var watchForParallel = Stopwatch.StartNew();
            //var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            //watchForParallel.Stop();

            //Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            //Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");

            //Console.WriteLine("Press any key to exit.");
            //---------------------------------------------

            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;

            Parallel.For<long>(0, nums.Length, () => 0, (j, loop, subtotal) =>
                 {
                     subtotal += nums[j];
                     return subtotal;
                 },
                    (x) => Interlocked.Add(ref total,x)
                 );

            Console.WriteLine("The total is {0:N0}", total);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();
        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }
        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
