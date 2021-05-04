using System;
using System.Collections.Generic;


namespace DynamicProgramming.Tabulation
{
    class BestSumTabulation
    {
        // m = targetSum ,n=numbers.length
        // Time : m^2 *n
        // Space : m^2
        public static int[] BestSum(int targetSum, int[] numbers)
        {
            int[][] array = new int[targetSum + 1][];
            array[0] = new int[0];


            for (int i = 0; i <= targetSum; i++)
            {
                if (array[i] != null)
                {
                    foreach (int number in numbers)
                    {
                        if (i + number <= targetSum)
                        {
                            int[] newCombi = new List<int>(array[i]) { number }.ToArray();
                            if (array[i + number] == null || array[i + number].Length > newCombi.Length)
                            {
                                array[i + number] = newCombi;
                            }

                        }
                    }
                }
            }

            return array[targetSum];
        }

        public static void Run()
        {
            Print(7, new int[] { 5, 3, 4, 7 });
            Print(0, new int[] { 5, 3, 4 });
            Print(8, new int[] { 4, 2, 4 });
            Print(300, new int[] { 14, 5 });
        }
        private static void Print(int sum, int[] numbers)
        {
            var x = BestSum(sum, numbers);
            if (x == null) Console.WriteLine("[]");
            else
            {
                Console.Write("[");
                foreach (var i in x)
                {
                    Console.Write($"{i} ,");
                }
                Console.WriteLine("]");
            }

        }
    }
}
