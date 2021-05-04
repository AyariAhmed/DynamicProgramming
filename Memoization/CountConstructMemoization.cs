using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Memoization
{
    class CountConstructMemoization
    {
        //Brute Force
        // Time = wordbank.length^(target.length) * target.length
        // Space = target.length^2

        //Memoization
        // Time : wordbank.length * target.length^2
        // Space = target.length^2
        public static int CountConstruct(string target, List<string> wordbank, Dictionary<string, int> memo = null)
        {
            memo = memo ?? new Dictionary<string, int>();
            if (memo.ContainsKey(target)) return memo[target];
            if (string.IsNullOrEmpty(target)) return 1;

            int totalCount = 0;

            foreach (var subString in wordbank)
            {
                if (target.StartsWith(subString))
                {
                    var suffix = target.Remove(0, subString.Length);
                    var numbWays = CountConstruct(suffix, wordbank, memo);
                    totalCount += numbWays;
                }

            }

            memo[target] = totalCount;
            return totalCount;

        }

        public static void Run()
        {

            Action<int> cw = Console.WriteLine;
            List<string> list1 = new List<string>() { "aa", "hm", "e", "a", "ed" };
            List<string> list0 = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            List<string> list2 = new List<string>() { "ea", "d", "k", "ka", "ked" };
            List<string> list3 = new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            List<string> list4 = new List<string>() { "e", "ee", "eee", "eeee", "eeeeee" };
            List<string> list5 = new List<string>() { "a", "p", "ent", "enter", "ot", "o", "t" };
            cw(CountConstruct("ahmed", list1));
            cw(CountConstruct("purple", list0));
            cw(CountConstruct("ahmed", list2));
            cw(CountConstruct("skateboard", list3));
            cw(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", list4));
            cw(CountConstruct("enterapotentpot", list5));
        }
    }
}
