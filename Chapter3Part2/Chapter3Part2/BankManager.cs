using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3Part2
{
    class BankManager:Human
    {
        private string name;
        public override string Name
        {
            get
            {
                return "Mr/Ms." + name;
            }
            set { }
        }
        public int Sallary
        {
            get;set;
        }
        public BankManager(int sallary,string name,int age,string social):base(age,social)
        {
            Sallary = sallary;
            Name = name;
        }
        public override void Display()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Status: {Social}, Sallary: {Sallary}");
        }
    }
}
