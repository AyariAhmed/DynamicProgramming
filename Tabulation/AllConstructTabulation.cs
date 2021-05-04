using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Tabulation
{
    // Not working , index out of the bounds of the array Exception 

    // m = target.length
    // n = wordBank.length
    //Time : n^m
    //Space : n^m
    class AllConstructTabulation
    {
        public static string[][] AllConstruct(string target, string[] words)
        {
            var m = target.Length;
            string[][][] array = new string[m + 1][][];
            array[0] = new string[1][] { new string[0] };

            for (int i = 0; i <= m; i++)
            {
                if (array[i] != null)
                {
                    foreach (string word in words)
                    {
                        if (target.Substring(i).StartsWith(word) && i + word.Length <= m)
                        {
                            if (array[i + word.Length] == null)
                            {
                                array[i + word.Length] = new string[array[i].Length][];
                                for (int j = 0; j <= array[i].Length; j++)
                                {
                                    array[i + word.Length][j] = new List<string>(array[i][j]) { word }.ToArray();
                                }
                            }
                            else
                            {
                                string[][] result = new string[array[i].Length + array[i + word.Length].Length][];
                                string[][] newArray = new string[array[i].Length][];
                                for (int j = 0; j <= array[i].Length; j++)
                                {
                                    newArray[j] = new List<string>(array[i][j]) { word }.ToArray();
                                }
                                array[i + word.Length].CopyTo(result, 0);
                                newArray.CopyTo(result, array[i].Length);
                                array[i + word.Length] = result;
                            }
                        }
                    }
                }
            }

            return array[m];
        }

        public static void Run()
        {
            Print("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
        }

        public static void Print(string target, string[] words)
        {
            var list = AllConstruct(target, words);
            if (list == null)
            {
                Console.WriteLine("Can't be constructed");
                return;
            }

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
