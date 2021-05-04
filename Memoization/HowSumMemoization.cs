using System;
using System.Collections.Generic;


namespace DynamicProgramming.Memoization
{
    class HowSumMemoization
    {
        //Time : targetSum * numbers_arrayLength * targetSum <- last one is for array copying
        //Space : TargetSum * TargetSum

        public static List<int> HowSum(int targetSum, List<int> numbers, Dictionary<int, List<int>> memo = null)
        {
            memo = memo ?? new Dictionary<int, List<int>>();
            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return new List<int>();
            if (targetSum < 0) return null;
            foreach (var n in numbers)
            {
                var remainder = targetSum - n;
                var result = HowSum(remainder, numbers, memo);
                if (result != null)
                {
                    var res = new List<int>(result);
                    res.Add(n);
                    // res array will be at most of size first_targetSum
                    memo[targetSum] = res;
                    return res;
                }
            }

            memo[targetSum] = null;
            return null;


        }

        public static void Run()
        {
            List<int> array = new List<int>() { 2, 4 };
            List<int> array2 = new List<int>() { 5, 3, 4, 7 };
            List<int> array3 = new List<int>() { 2, 4 };
            List<int> array4 = new List<int>() { 2, 3, 5 };
            List<int> array5 = new List<int>() { 14, 7, 15 };
            print(7, array);
            print(7, array2);
            print(7, array3);
            print(8, array4);
            print(300, array5);




        }

        public static void print(int n, List<int> array)
        {
            if (HowSum(n, array) != null)
            {
                foreach (var i in HowSum(n, array))
                {
                    Console.Write($"{i} | ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Can't be summed!");
            }
        }
    }
}
