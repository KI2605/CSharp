using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskEqualStrings
{
    class Program
    {
        public static Dictionary<char,int> makeDict(Dictionary<char,int> str1,string string1)
        {

            char[] lits1 = string1.ToArray();
            int j = 0;
            while (j < lits1.Length)
            {
                int count = 0;
                char el = lits1[j];
                for (int i = 0; i < lits1.Length; i++)
                {
                    if (el == lits1[i])
                    {
                        count++;
                    }
                }
                if (!str1.ContainsKey(el))
                {
                    str1.Add(el, count);
                }
                j++;
            }
            return str1;
        }
        public static string Anagramm(string string1, string string2)
        {
            
            Dictionary<char, int> str1 = new Dictionary<char, int>();
            Dictionary<char, int> str2 = new Dictionary<char, int>();
            makeDict(str1, string1);
            Console.WriteLine(str1.Count);
            makeDict(str2, string2);
            //отсортировать
            Console.WriteLine(str2.Count);
            if (str1.Count == str2.Count)
            {
                int flag = 1;
                int j = 0;
                while (j < str1.Count && flag!=0)
                {
                    foreach (char c in str2.Keys) {
                        if (str1.ContainsKey(c) && str1[c]==str2[c])
                        {
                            flag = 1;
                            j++;
                        }
                        else
                        {
                            flag = 0;
                            return "no";
                        }
                    }
                }

            }
            return "yes";
        }
        static void Main(string[] args)
        {
            string string1 = "school master1"; 
            string string2 = "the classroom2";
            Console.WriteLine(Anagramm(string1, string2));
        }
    }
}
