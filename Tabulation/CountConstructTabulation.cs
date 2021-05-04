using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Tabulation
{
    class CountConstructTabulation
    {
        // Time : wordbank.length * target.length^2
        // Space = target.length
        public static int CountConstruct(string target, string[] words)
        {
            var m = target.Length;
            int[] array = new int[m + 1];
            array[0] = 1;

            for (int i = 0; i <= m; i++)
            {
                if (array[i] != 0)
                {
                    foreach (string word in words)
                    {
                        if (target.Substring(i).StartsWith(word))
                        {
                            if (i + word.Length <= m)
                                array[i + word.Length] += array[i];
                        }
                    }
                }
            }

            return array[m];
        }

        public static void Run()
        {
            Action<int> cw = Console.WriteLine;
            var list1 = new string[] { "aa", "hm", "e", "a", "ed" };
            var list0 = new string[] { "purp", "p", "ur", "le", "purpl" };
            var list2 = new string[] { "ea", "d", "k", "ka", "ked" };
            var list3 = new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" };
            var list4 = new string[] { "e", "ee", "eee", "eeee", "eeeeee" };
            var list5 = new string[] { "a", "p", "ent", "enter", "ot", "o", "t" };
            cw(CountConstruct("ahmed", list1));//1
            cw(CountConstruct("purple", list0));//2
            cw(CountConstruct("ahmed", list2));//0
            cw(CountConstruct("skateboard", list3));//0
            cw(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", list4));//0
            cw(CountConstruct("enterapotentpot", list5));//4
        }
    }
}
