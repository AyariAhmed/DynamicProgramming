﻿using System;
using System.Collections.Generic;


namespace DynamicProgramming
{
    class CanConstructMemoization
    {
        public static bool CanConstruct(string target, List<string> wordBank, Dictionary<string, bool> memo = null)
        {
            memo = memo ?? new Dictionary<string, bool>();
            if (memo.ContainsKey(target)) return memo[target];
            if (String.IsNullOrEmpty(target)) return true;

            foreach (string subString in wordBank)
            {
                if (target.StartsWith(subString)) // You can only remove prefixes
                {
                    var newString = target.Remove(0, subString.Length);

                    if (CanConstruct(newString, wordBank, memo))
                    {
                        memo[newString] = true;
                        return true;
                    }
                }
            }

            memo[target] = false;
            return false;

        }

        public static void Run()
        {
            Action<bool> cw = Console.WriteLine;
            List<string> list1 = new List<string>() { "aa", "hm", "e", "a", "ed" };
            List<string> list2 = new List<string>() { "ea", "d", "k", "ka", "ked" };
            List<string> list3 = new List<string>() { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            List<string> list4 = new List<string>() { "e", "ee", "eee", "eeee", "eeeeee" };
            List<string> list5 = new List<string>() { "a", "p", "ent", "enter", "ot", "o", "t" };
            cw(CanConstruct("ahmed", list1));
            cw(CanConstruct("ahmed", list2));
            cw(CanConstruct("skateboard", list3));
            cw(CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", list4));
            cw(CanConstruct("enterapotentpot", list5));

        }
    }
}
