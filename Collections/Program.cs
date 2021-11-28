using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnionWith();
            program.IntersectWith();

            Console.ReadKey();
        }

        internal void RemoveDuplicates()
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(1); //Removes Duplicates
            set.Add(2);

            foreach (var itm in set)
            {
                Console.WriteLine(itm); ;
            }
        }
        internal void UnionWith()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();
            for(int i = 0; i < 5; i++)
            {
                evenNumbers.Add(i*2);
                oddNumbers.Add((i*2)+1);
            }
            Console.WriteLine("evenNumbers contains {0} elements: ", evenNumbers.Count);
            DisplaySet(evenNumbers);

            Console.WriteLine("oddNumbers contains {0} elements: ", oddNumbers.Count);
            DisplaySet(oddNumbers);

            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Console.WriteLine("numbers contains {0} elements: ", numbers.Count);
            DisplaySet(numbers);

        }
        internal void IntersectWith()
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                firstSet.Add(i * 2);
                secondSet.Add(i * 4);
            }
            Console.WriteLine("FirstSet contains {0} elements: ", firstSet.Count);
            DisplaySet(firstSet);

            Console.WriteLine("SecondSet contains {0} elements: ", secondSet.Count);
            DisplaySet(secondSet);

            HashSet<int> intersectSet = new HashSet<int>(firstSet);
            Console.WriteLine("FirstSet UnionWith SecondSet...");
            intersectSet.IntersectWith(secondSet);

            Console.WriteLine("intersectSet contains {0} elements: ", intersectSet.Count);
            DisplaySet(intersectSet);
        }
        internal void DisplaySet(HashSet<int> collection)
        {
            Console.Write("{");
            foreach (int i in collection)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }
    }
}
