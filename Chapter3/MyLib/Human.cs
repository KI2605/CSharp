using System;

namespace MyLib
{
    public class Human
    {
        public string name;
        private int age;

        public int Age
        {
            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Возраст должен быть больше 17");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }
    }
}
