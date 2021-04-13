using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskEqualStringsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = Console.ReadLine();
            string string2 = Console.ReadLine();
            Console.WriteLine( LinqAnagram(string1, string2));
        }

        public static string LinqAnagram(string string1, string string2)
        {
            var st1 = from i in string1
                      select i;

            var sst1 = st1.OrderBy(Char.ToUpper).ThenBy(c => c).ToArray();

            var ssst1 = sst1.GroupBy(sst1 => sst1).Select(g => (val: g.Key, col: g.Count()));

            var st2 = from i in string2
                      select i;

            var sst2 = st2.OrderBy(Char.ToUpper).ThenBy(c => c).ToArray();

            var ssst2 = sst2.GroupBy(sst2 => sst2).Select(g => (val: g.Key, col: g.Count()));

            var res = from s1 in ssst1
                      join s2 in ssst2
                      on s1.val equals s2.val
                      where s1.col == s2.col
                      select s1;
            int countres = 0;
            int countstr1 = 0;
            foreach (var i in ssst1)
            {
                Console.WriteLine($"char:{i.val} count:{i.col}");
                countstr1++;
            }
            Console.WriteLine("-------");
            foreach (var i in res)
            {
                Console.WriteLine($"char:{i.val} count:{i.col}");
                countres++;
            }
            Console.WriteLine(countres);
            Console.WriteLine(countstr1);
            if (countres != countstr1)
            {
                return "no";
            }
            else
            {
                return "yes";
            }
        }
    }
}
