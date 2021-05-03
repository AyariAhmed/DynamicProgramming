using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    class BestSumMemoization
    {
        //Brute force
        //Time : numbers_arrayLength^targetSum * targetSum
        //Space : TargetSum^2

        //Memoized
        //Time : targetSum^2 * numbers_arrayLength 
        //Space : TargetSum^2
        public static List<int> BestSum(int targetSum, List<int> numbers, Dictionary<int, List<int>> memo = null)
        {
            memo = memo ?? new Dictionary<int, List<int>>();
            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return new List<int>();
            if (targetSum < 0) return null;

            List<int> shortestCombination = null;

            foreach (int n in numbers)
            {
                if (n > 0)
                {
                    var remainder = targetSum - n;
                    var result = BestSum(remainder, numbers, memo);

                    if (result != null)
                    {
                        var res = new List<int>(result);
                        res.Add(n);
                        if (shortestCombination == null || res.Count < shortestCombination.Count)
                        {
                            shortestCombination = res;
                        }
                    }
                }
            }
            memo[targetSum] = shortestCombination != null ? new List<int>(shortestCombination) : null;
            return shortestCombination;

        }

        public static void Run()
        {
            List<int> array = new List<int>() { 1 };
            List<int> array2 = new List<int>() { 2, 3, 5 };
            List<int> array3 = new List<int>() { 1, 4, 5 };
            List<int> array4 = new List<int>() { 1, 2, 5, 25 };
            print(7, array);
            print(8, array2);
            print(8, array3);
            print(100, array4);
        }

        public static void print(int n, List<int> array)
        {
            if (BestSum(n, array) != null)
            {
                foreach (var i in BestSum(n, array))
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
