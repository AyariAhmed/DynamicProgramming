using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    public class CanSumMemoization
    {
        //Time : targetSum * numbers_arrayLength
        //Space : TargetSum
        public static bool CanSum(int targetSum, List<int> numbers, Dictionary<int, bool> memo = null)
        {
            memo = memo ?? new Dictionary<int, bool>();
            if (memo.ContainsKey(targetSum)) return memo[targetSum];
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;
            foreach (var n in numbers)
            {
                if (CanSum(targetSum - n, numbers, memo))
                {
                    memo[targetSum] = true;
                    return true;

                };
            }

            memo[targetSum] = false;
            return false;
        }

        public static void Run()
        {
            List<int> array = new List<int>() { 2, 3 };
            List<int> array2 = new List<int>() { 5, 3, 4, 7 };
            List<int> array3 = new List<int>() { 2, 4 };
            List<int> array4 = new List<int>() { 2, 3, 5 };
            List<int> array5 = new List<int>() { 14, 7 };
            Console.WriteLine(CanSum(7, array));
            Console.WriteLine(CanSum(7, array2));
            Console.WriteLine(CanSum(7, array3));
            Console.WriteLine(CanSum(8, array4));
            Console.WriteLine(CanSum(300, array5));

        }
    }
}