using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Part2
{
    public class Person
    {
        string nam;
        int ag;
        public Person()
        {
            
        }
        public Person(string name)
        {
            this.nam = name;
        }
        public Person(string name, int age) : this(name)
        {
            this.ag = age;
        }

        public string Name
        {
            set
            {
                nam = value;
            }
            get
            {
                return this.nam;
            }
        }
        public int Age
        {
            set
            {
                ag = value;
            }
            get
            {
                return this.ag;
            }
        }
        ~Person()
        {

        }
    }
}
