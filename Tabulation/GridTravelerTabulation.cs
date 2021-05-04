using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Tabulation
{
    class GridTravelerTabulation
    {
        // Time : m*n
        // Space : m*n
        public static long GridTraveler(int m, int n)
        {
            if (m == 0 || n == 0) return 0;
            long[,] array = new long[m + 1, n + 1];
            array[1, 1] = 1;
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i + 1 <= m) array[i + 1, j] += array[i, j];
                    if (j + 1 <= n) array[i, j + 1] += array[i, j];
                }
            }

            return array[m, n];
        }

        public static void Run()
        {
            Action<long> cw = Console.WriteLine;
            cw(GridTraveler(1, 1));
            cw(GridTraveler(0, 0));
            cw(GridTraveler(2, 3));
            cw(GridTraveler(3, 3));
            cw(GridTraveler(18, 18));
        }
    }
}
