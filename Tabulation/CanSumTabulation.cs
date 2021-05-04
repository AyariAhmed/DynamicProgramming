using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Tabulation
{
    class CanSumTabulation
    {
        // m = targetSum ,n=numbers.length
        // Time : m*n
        // Space : m
        public static bool CanSum(int targetSum, List<int> numbers)
        {
            bool[] array = new bool[targetSum + 1];
            array[0] = true;
            for (int i = 0; i <= targetSum && array[targetSum] == false; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (array[i] && i + numbers[j] <= targetSum) array[i + numbers[j]] = true;
                }

            }
            return array[targetSum];
        }

        public static void Run()
        {
            Action<bool> cw = Console.WriteLine;
            cw(CanSum(7, new List<int>() { 5, 3, 4 }));
            cw(CanSum(7, new List<int>() { 3 }));
            cw(CanSum(0, new List<int>() { 5 }));
            cw(CanSum(150, new List<int>() { 126, 6, 27 }));

        }
    }
}
