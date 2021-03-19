using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Strana
    {
            public int Population { get; set; } // население
            public int Area { get; set; }       // территория
       
        public static Strana operator +(Strana s1,Strana s2)
        {
            return new Strana { Population = s1.Population + s2.Population,Area = s1.Area + s2.Area };
        }
        public static bool operator >(Strana s1, Strana s2) => s1.Population > s2.Population;
        public static bool operator <(Strana s1, Strana s2) => s1.Population < s2.Population;
    }
    }

