using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class GridTravelerMemoization
    {

        //Time : m*n
        //Space : m+n
        private static readonly Dictionary<(int, int), long> memo = new Dictionary<(int, int), long>();

        public static long GridTraveler(int m, int n)
        {
            if (memo.ContainsKey((m, n))) return memo[(m, n)];
            if (memo.ContainsKey((n, m))) return memo[(n, m)];
            else if (m == 0 || n == 0) return 0;
            else if (m == 1 && n == 1) return 1;
            else
            {
                var value = GridTraveler(m - 1, n) + GridTraveler(m, n - 1);
                memo.Add((m, n), value);
                return value;
            }
        }

        public static void Run()
        {
            Console.Write("m = ");
            int m = Int32.Parse(Console.ReadLine());
            Console.Write("n = ");
            int n = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"GridTraveler({m},{n}) = {GridTraveler(m, n)}");
        }
    }
}