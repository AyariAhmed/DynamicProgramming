using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    class AllConstructMemoization
    {
        public static List<List<string>> AllConstruct(string target, List<string> wordbank)
        {
            if (string.IsNullOrEmpty(target)) return new List<List<string>>() { new List<string>() };
            foreach (var word in wordbank)
            {
                if (target.StartsWith(word))
                {
                    var suffix = target.Remove(0, word.Length);
                }
            }

        }

        public static void Run()
        {
            List<string> list1 = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            List<string> list2 = new List<string>() { "ab", "abc", "cd", "def", "abcd", "ef", "c" };
            List<string> list3 = new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            List<string> list41 = new List<string>() { "a", "aa", "aaa", "aaaa" };

        }

        public static void Print(List<List<string>> list)
        {
            Console.WriteLine("[");
            foreach (var subList in list)
            {
                Console.Write("[");
                foreach (var e in subList)
                {
                    Console.Write($"{e} ,");
                }
                Console.Write("]");
            }
            Console.WriteLine("]");
        }
    }
}
