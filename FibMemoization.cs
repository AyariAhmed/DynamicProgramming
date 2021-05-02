using System;
using System.Collections.Generic;
using System.Linq;


namespace DynamicProgramming
{
    class FibMemoization
    {
        //Time : n
        //Space : n
        private static readonly Dictionary<int, long> dict = new Dictionary<int, long>()
        {
            {0,0},{1,1}
        };
        public static long Fib(int n)
        {
            if (dict.ContainsKey(n)) return dict[n];
            var value = Fib(n - 1) + Fib(n - 2);
            dict.Add(n, value);
            return value;
        }

        public static void Run()
        {
            Console.Write("n = ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Fib({n}) = {Fib(n)}");

        }
    }
}
