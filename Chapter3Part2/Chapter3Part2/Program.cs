using System;

namespace Chapter3Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine("Input an age");
            //int age = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Input a name");
            //string name = Console.ReadLine();
            //Person p = new Person(name,age);
            //Console.WriteLine($"Name:{name} Age:{age}");
           // Employee[] emps = new Employee[5];
           // for(int i = 0; i < emps.Length; i++)
           // {
           //     Console.WriteLine("Input an age");
           //     int age = Int32.Parse(Console.ReadLine());
           //     Console.WriteLine("Input a name");
           //     string name = Console.ReadLine();
           //     Console.WriteLine("Input company's name:");
           //     string company = Console.ReadLine();
           //     emps[i] = new Employee(name,age,company);
               
           // }
           //foreach(Employee emp in emps)
           // {
           //     Console.WriteLine($"COMPANY: {emp.Company} NAME: {emp.Name} AGE: {emp.Age}");
           // }

            //Console.WriteLine("/n");
            //Clock clock = new Clock { Hours = 240 };
            //int x = (int)clock;
            //Console.WriteLine(x);
            //Clock clock2 = 13;
            //Console.WriteLine(clock2.Hours);
            //clock2 = 34;
            //Console.WriteLine(clock2.Hours);
            //Dollar dollar = new Dollar();
            //dollar.Sum = 40;
            //Euro euro = new Euro();
            //euro = (Euro) dollar;
            //Console.WriteLine($"ljjkkk {euro.Sum}");

            LongCredit credit = new LongCredit { Sum = 6000 };
            credit.Sum = 490;
            Console.WriteLine(credit.Sum);

            Per pe = new Per();
            pe.Name = "Cody";
            Emp em = new Emp();
            em.Name = "Lop";
            Console.WriteLine($"{em.Name}");
            pe.Name = em.Name;
            Console.WriteLine($"{pe.Name}");

            Human h1 = new Client (10000,"Joe Doe", 32, "Client");
            Human h2 = new BankManager(2000, "Jack Barret", 24, "Mananger");
            h1.Display();
            h2.Display();

            object person = new Person { Name = "Tom" };
            if (person.GetType() == typeof(Person))
                Console.WriteLine("Это реально класс Person");

            Person person1 = new Person { Name = "Tom" };
            Person person2 = new Person { Name = "Bob" };
            Person person3 = new Person { Name = "Tom" };
            bool p1Ep2 = person1.Equals(person2);   // false
            Console.WriteLine(p1Ep2);
            bool p1Ep3 = person1.Equals(person3);   // true

            //Account<int> account1 = new Account<int> { Sum = 5000 };
            //Account<string> account2 = new Account<string> { Sum = 4000 };
            //account1.Id = 2;        // упаковка не нужна
            //account2.Id = "4356";
            //int id1 = account1.Id;  // распаковка не нужна
            //string id2 = account2.Id;
            //Console.WriteLine(id1);
            //Console.WriteLine(id2);

            Collection<int> numbers = new Collection<int>();
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);

            numbers.Remove(2); // попытка удалить элемента, которого нет в коллекции
            numbers.Remove(3);


            for (int i = 0; i < numbers.Count(); i++)
            {
                Console.WriteLine(numbers.GetItem(i));
            }

            Account<int> acc1 = new Account<int>(1857) { Sum = 4500 };
            Account<int> acc2 = new Account<int>(3453) { Sum = 5000 };

            Transact<Account<int>>(acc1, acc2, 900);
        }
        public static void Transact<T>(T acc1, T acc2, int sum) where T : Account<int>
        {
            if (acc1.Sum > sum)
            {
                acc1.Sum -= sum;
                acc2.Sum += sum;
            }
            Console.WriteLine($"acc1: {acc1.Sum}   acc2: {acc2.Sum}");
        }
    }
    class Clock
    {
        public int Hours { get; set; }
       public static implicit operator Clock(int time)
        {
            return new Clock { Hours = time % 24 };
        } 
        public static explicit operator int(Clock clock)
        {
            return clock.Hours;
        }
    }
    class Dollar
    {
        public decimal Sum { get; set; }
    }
    class Euro
    {
        public decimal Sum { get; set; }
        public static explicit operator Euro(Dollar dollar)
        {
            return new Euro {Sum = dollar.Sum * 1.14M};
        }
        public static explicit operator Dollar(Euro euro)
        {
            return new Dollar { Sum = euro.Sum / 1.14M };
        }
    }
    class Credit
    {
        public virtual decimal Sum { get; set; }
    }
    class LongCredit : Credit
    {
        private decimal sum;
        public override decimal Sum
        {
            get
            {
                return sum;
            }
            set
            {
                if (value > 1000)
                {
                    sum = value;
                }
            }
        }
      

    }
    class Per
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    class Emp : Per
    {
        public new string Name
        {
            get { return "Employee " + base.Name; }
            set { name = value; }
        }
    }
    class Account<T>
    {
        T id = default(T);
        public T Id { get; set; }
        public int Sum { get; set; }
        public Account(T _id)
        {
            Id = _id;
        }
    }
    class Collection<T>
    {
        T[] data;   // массив с данными
        public Collection()
        {
            data = new T[0];
        }
        // добавление данных
        public void Add(T item)
        {
            T[] newData = new T[data.Length + 1];
            for (int i = 0; i < data.Length; i++)
            {
                newData[i] = data[i];
            }
            newData[data.Length] = item;
            data = newData;
        }
        // удаление данных - удаляем первое вхождение элемента при его наличии
        public void Remove(T item)
        {
            // находим индекс элемента
            int index = -1;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            // удаляем элемент по индексу
            if (index > -1)
            {
                T[] newData = new T[data.Length - 1];
                for (int i = 0, j = 0; i < data.Length; i++)
                {
                    if (i == index) continue;
                    newData[j] = data[i];
                    j++;
                }
                data = newData;
            }
        }
        // получение элемента по индексу
        public T GetItem(int index)
        {
            if (index > -1 && index < data.Length)
            {
                return data[index];
            }
            else
                throw new IndexOutOfRangeException();
        }
        public int Count()
        {
            return data.Length;
        }
    }
}
