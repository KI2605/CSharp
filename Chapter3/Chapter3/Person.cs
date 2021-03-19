using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Person
    {
        public string name;
        public int age;

        public Person() { name = "Неизвестно"; age = 18; }      // 1 конструктор

        public Person(string n) { name = n; age = 18; }         // 2 конструктор

        public Person(string n, int a) { name = n; age = a; }   // 3 конструктор
        public void SetInfo()
        {
            name = Console.ReadLine();
            age = Int32.Parse(Console.ReadLine());
        }
        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }

    }
    //    public string name;
    //    public int age;

    //    public Person() : this("Неизвестно")
    //    {
    //    }
    //    public Person(string name) : this(name, 18)
    //    {
    //    }
    //    public Person(string name, int age)
    //    {
    //        this.name = name;
    //        this.age = age;
    //    }
    //    public void GetInfo()
    //    {
    //        Console.WriteLine($"Имя: {name}  Возраст: {age}");
    //    }
    //}
}

