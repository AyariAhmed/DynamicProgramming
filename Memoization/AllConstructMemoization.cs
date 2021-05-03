using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace DynamicProgramming
{
    class AllConstructMemoization
    {
        // m = target.length
        // n = wordBank.length
        //Time : n^m
        //Space : m
        public static List<List<string>> AllConstruct(string target, List<string> wordbank, Dictionary<string, List<List<string>>> memo = null)
        {
            memo = memo ?? new Dictionary<string, List<List<string>>>();
            if (memo.ContainsKey(target)) return memo[target];
            if (string.IsNullOrEmpty(target)) return new List<List<string>>() { new List<string>() };

            var result = new List<List<string>>();

            foreach (var word in wordbank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Remove(0, word.Length);
                    var suffixWays = AllConstruct(suffix, wordbank, memo);

                    var targetWays = (List<List<string>>)suffixWays.Select(way =>
                    {
                        var l = new List<string>(way);
                        l.Insert(0, word);
                        return l;
                    }).ToList<List<string>>();

                    foreach (var targetWay in targetWays)
                    {
                        result.Add(targetWay);

                    }
                }
            }

            memo[target] = result;
            return result;

        }

        public static void Run()
        {
            List<string> list1 = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            List<string> list2 = new List<string>() { "ab", "abc", "cd", "def", "abcd", "ef", "c" };
            List<string> list3 = new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            List<string> list4 = new List<string>() { "a", "aa", "aaa", "aaaa" };
            Print("purple", list1);
            Print("abcdef", list2);
            Print("skateboard", list3);
            Print("aaaaaaaaaaaaaaaaaaaaaaaaaaz", list4);

        }

        public static void Print(string target, List<string> words)
        {
            var list = AllConstruct(target, words);


            foreach (var subList in list)
            {
                Console.Write("[ ");
                foreach (var e in subList)
                {
                    Console.Write($"{e} ");
                }
                Console.WriteLine("]");
            }

            Console.WriteLine("---------------------------------------------------");
        }
    }
}
