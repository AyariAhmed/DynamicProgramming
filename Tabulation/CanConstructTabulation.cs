using System;


namespace DynamicProgramming.Tabulation
{
    // m = target.length
    // n = wordbank.length
    // Time : m^2 * n
    // Space : m
    class CanConstructTabulation
    {
        public static bool CanConstruct(string target, string[] words)
        {
            var m = target.Length;
            bool[] array = new bool[m + 1];
            array[0] = true;
            for (int i = 0; i <= m; i++)
            {
                if (array[i])
                {
                    foreach (string word in words)
                    {
                        if (target.Substring(i).StartsWith(word))
                        {
                            if (i + word.Length <= m) array[i + word.Length] = true;
                        }
                    }
                }
            }

            return array[m];
        }

        public static void Run()
        {
            Action<bool> cw = Console.WriteLine;
            var list1 = new string[] { "aa", "hm", "e", "a", "ed" };
            var list2 = new string[] { "ea", "d", "k", "ka", "ked" };
            var list3 = new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            var list4 = new string[] { "e", "ee", "eee", "eeee", "eeeeee" };
            var list5 = new string[] { "a", "p", "ent", "enter", "ot", "o", "t" };
            cw(CanConstruct("ahmed", list1));
            cw(CanConstruct("ahmed", list2));
            cw(CanConstruct("skateboard", list3));
            cw(CanConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", list4));
            cw(CanConstruct("", list4));
            cw(CanConstruct("enterapotentpot", list5));

        }
    }
}
