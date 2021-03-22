using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Part2
{
    class Client:Human
    {
        private string name;
        public override string Name
        {
            get
            {
                return "Mr/Ms." + name;
            }
            set
            {

            }
        }
        public int Sum
        {
            get;
            set;
        }
        public Client(int sum,string name,int age,string social) : base(age, social)
        {
            Sum = sum;
            Name += name;
        }
        public override void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Status: {Social}, Sum: {Sum}");
        }
    }
}
