using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Part2
{
    class Employee:Person
    {
        string company;
        public Employee(string name,int age,string company) : base(name, age)
        {
            this.company = company;
        }
        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }
    }
}
