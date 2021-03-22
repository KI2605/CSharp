using System;
using static System.Console;
using MyLib;
namespace Chapter3
{
    class Program
    {
        struct User
        {
            public string name;
            public int age;
            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Age: {age}");
            }
        }
        struct State
        {
            public int x;
            public int y;
            public Country country;
        }
        class Country
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Person p=new Person();
            //Person s = new Person("Tom", 21);
            //p.SetInfo();
            //p.GetInfo();
            //s.GetInfo();
            //User u = new User { name = "Tom", age = 89 };
            //u.DisplayInfo();
            //User a = new User("Alex", 19);
            //a.DisplayInfo();
            //User b = new User();
            //b.DisplayInfo();

            //
            State state1 = new State();
            State state2 = new State();

            state2.country = new Country();
            state2.country.x = 5;
            state1 = state2;
            state2.country.x = 8; // теперь и state1.country.x=8, так как state1.country и state2.country
                                  // указывают на один объект в хипе
            Console.WriteLine(state1.country.x); // 8
            Console.WriteLine(state2.country.x); // 8
            Console.WriteLine("-----------------/n");
            //
                Person p = new Person { name = "Tom", age = 23 };
                ChangePerson(ref p);

                WriteLine(p.name); // Bill
                WriteLine(p.age); // 45
            Console.WriteLine("-----------------/n");
            //
            Human j = new Human { name = "Jack"};
            Console.WriteLine("Please, tell me your age");
            j.Age = Int32.Parse(ReadLine());
            WriteLine($"Name: {j.name} Age: {j.Age}");
            Console.WriteLine("-----------------/n");
            //
            Access acc = new Access();
            acc.internalMethod();
            acc.protectedInternalMethod();
            acc.publicMethod();

            Console.WriteLine("-----------------/n");
            //
            int v = Int32.Parse(ReadLine());
            IncrementVal(v);
            IncrementVal(ref v);
            
            Console.WriteLine(v);
            Console.WriteLine("sum");
            decimal sum = Decimal.Parse(ReadLine());
            Console.WriteLine("rate");
            decimal rate = Decimal.Parse(ReadLine());
            Console.WriteLine("period");
            int period = Int32.Parse(ReadLine());
            Console.WriteLine(Account.GetSum(sum,rate,period));
            Console.WriteLine("-----------------/n");
            //
            Uther uth = new Uther("rob",67);
            Console.WriteLine(uth.Age);
            Console.WriteLine("-----------------/n");
            //
            Strana ss1 = new Strana();
            ss1.Area = 120000;
            ss1.Population = 1000000;
            Strana ss2 = new Strana();
            ss2.Area = 150000;
            ss2.Population = 750000;
            Strana state3 = ss1 + ss2;
            bool isGreater = ss1 > ss2;
            if (isGreater == true)
            {
                Console.WriteLine($"Greater is {ss1}");
            }
            else if (isGreater == false)
            {
                Console.WriteLine($"Greater is {ss2}");
            }
            
            Console.WriteLine($"New Country population={state3.Population} New Country Area={state3.Area}");
            Console.WriteLine("-----------------/n");
            //
            Bread bread = new Bread { Weight = 80 };
            Butter butter = new Butter { Weight = 20 };
            Sandwich sandwich = bread + butter;
            Console.WriteLine(sandwich.Weight);

            Console.WriteLine("-----------------/n");
            ///

            People people = new People();
            people[0] = new Pers { Name = "Tom" };
            people[1] = new Pers { Name = "Bob" };

            Console.WriteLine(people[0].Name);      // Tom
            Console.WriteLine(people["Bob"].Name);  // Bob
            Console.WriteLine("-----------------/n");

            Team team = new Team();
            team[20] = new FootballPlayer { Name = Console.ReadLine(), Number = Int32.Parse(Console.ReadLine()) };
            //team[0] = new FootballPlayer { Name = "Ronaldo", Number = 9 };
            Console.WriteLine($"Name: {team[0].Name} Number: {team[0].Number}");
            Read();

        }
        static void ChangePerson(ref Person person)
        {
            // сработает
            person.name = "Alice";
            // сработает
            person = new Person { name = "Bill", age = 45 };

        }
        static void IncrementVal(ref int val)
        {
            val++;
            Console.WriteLine(val);
        }
        static void IncrementVal(int val)
        {
            val++;
            Console.WriteLine(val);
        }

        readonly struct Uther
        {
            public readonly string Name { get; } // указывать readonly необязательно
            public int Age { get; } // свойство только для чтения
            public Uther(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }

        class Bread
        {
            public int Weight { get; set; } // масса
            public static Sandwich operator +(Bread br, Butter b)
            {
                return new Sandwich { Weight = br.Weight + b.Weight };
            }
        }

        // масло
        class Butter
        {
            public int Weight { get; set; } // масса
        }

        // бутерброт
        class Sandwich
        {
            
            public int Weight { get; set; } // масса
            
        }

        class Pers
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        class People
        {
            Pers[] data;
            public People()
            {
                data = new Pers[5];
            }
            public Pers this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }
            public Pers this[string name]
            {
                get
                {
                    Pers person = null;
                    foreach (var p in data)
                    {
                        if (p?.Name == name)
                        {
                            person = p;
                            break;
                        }
                    }
                    return person;
                }
            }
        }
    }
}
