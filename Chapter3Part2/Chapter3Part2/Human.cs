using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Part2
{
    public abstract class Human
    {
        public abstract string Name { get; set; }
        public int Age { get; set; }
        public string Social { get; set; }
        public Human(int age,string social)
        {
    
            Age = age;
            Social = social;
        }
        public abstract void Display();
    }
}
