using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Tabulation
{
    class FibTabulation
    {
        // Time : n
        // Space : n
        public static long Fib(int n)
        {
            if (n <= 0) return 0;
            List<long> list = new List<long>(new long[n + 1]);
            list[1] = 1;
            for (int i = 1; i < n - 1; i++)
            {
                list[i + 1] += list[i];
                list[i + 2] += list[i];
            }

            return list[n] + list[n - 1];
        }


        public static void Run()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"fib({n}) = {Fib(n)}");
        }
    }
}
